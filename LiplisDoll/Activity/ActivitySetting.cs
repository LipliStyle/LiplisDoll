﻿//=======================================================================
//  ClassName : ActivitySetting
//  概要      : 設定アクティビティ
//
//  Liplis2.3
//  2013/06/20 Liplis2.3.0 設定画面一新
//  Copyright(c) 2010-2013 LipliStyle.Sachin
//
//
//  何もしないのにウインドウが出てきてしまう場合は、最小化/最大化メソッドを確認
//=======================================================================
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Liplis.Common;
using Liplis.Fct;
using Liplis.MainSystem;
using Liplis.Msg;
using Liplis.Web;

namespace Liplis.Activity
{
    public partial class ActivitySetting : BaseSystem
    {
        ///====================================================================
        ///
        ///                             初期化処理
        ///                         
        ///====================================================================

        ///=====================================
        /// オブジェクト
        private Liplis.MainSystem.Liplis lips;
        private ObjSetting os;
        private ObjWindowFile owf;

        ///=====================================
        /// フラグ
        private bool flgEnd = false;
        private bool flgLoad = false;

        ///=====================================
        /// 地域辞書
        private Dictionary<int, string> regionDic;

        ///============================
        /// デリゲート
        #region デリゲート
        private static LpsDelegate.dlgBmpToVoid reqSetBackGround;
        #endregion

        ///====================================================================
        ///
        ///                              onCreate
        ///                         
        ///====================================================================

        //コンストラクター
        #region ActivitySetting : base()
        public ActivitySetting(Liplis.MainSystem.Liplis lips, ObjSetting os, ObjWindowFile owf)
            : base()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.lips = lips;
            this.os = os;
            this.owf = owf;
            this.initSettingWindow();
            this.initSetting();
            this.initDelegate();
            this.flgLoad = true;
        }
        #endregion

        /// <summary>
        /// initSettingWindow
        /// initSettingWindowの初期化
        /// </summary>
        #region initSettingWindow
        private void initSettingWindow()
        {
            this.Opacity = 1;
        }
        #endregion

        /// <summary>
        /// initDelegate
        /// delegateの初期化
        /// </summary>
        #region initDelegate
        private void initDelegate()
        {
            //セットバックグラウンド
            reqSetBackGround = new LpsDelegate.dlgBmpToVoid(dlgSetBackGround);
        }
        #endregion

        /// <summary>
        /// initSetting
        /// initSettingの初期化
        /// </summary>
        #region initSetting
        private void initSetting()
        {
            //アクティブ度
            this.trackSpeed.Value = reversePercent(os.lpsReftesh);
            this.txtSpeed.Text = os.lpsReftesh.ToString();
            if (os.lpsReftesh == 0)
            {
                rboEco.Checked = true;

            }
            else if (os.lpsReftesh <= 25)
            {
                rboYukkuri.Checked = true;
            }
            else if (os.lpsReftesh <= 50)
            {
                rboLittleYukkuri.Checked = true;
            }
            else if (os.lpsReftesh <= 75)
            {
                rboNormal.Checked = true;
            }
            else
            {
                rboOtenba.Checked = true;
            }


            regionDic = LpsDefineRegion.getRegionDictionary();

            //ウインドウ
            setWindowImage(this.rbWindow1, this.picWindow1, 0);
            setWindowImage(this.rbWindow2, this.picWindow2, 1);
            setWindowImage(this.rbWindow3, this.picWindow3, 2);
            setWindowImage(this.rbWindow4, this.picWindow4, 3);
            setWindowImage(this.rbWindow5, this.picWindow5, 4);
            setWindowImage(this.rbWindow6, this.picWindow6, 5);
            setWindowImage(this.rbWindow7, this.picWindow7, 6);

            //ウインドウの選択
            switch(os.window)
            {
                case 0:
                    rbWindow1.Checked = true;
                    break;
                case 1:
                    rbWindow2.Checked = true;
                    break;
                case 2:
                    rbWindow3.Checked = true;
                    break;
                case 3:
                    rbWindow4.Checked = true;
                    break;
                case 4:
                    rbWindow5.Checked = true;
                    break;
                case 5:
                    rbWindow6.Checked = true;
                    break;
                case 6:
                    rbWindow7.Checked = true;
                    break;
                default:
                    rbWindow1.Checked = true;
                    break;
            }

            //ウインドウ追随設定
            chkWindowChase.Checked = LpsLiplisUtil.bitToBool(os.talkChase);

            //詳細ウインドウ表示
            chkVoice.Checked = LpsLiplisUtil.bitToBool(os.lpsVoiceOn);

            //ボイス設定
            cmbVoiceSelect.SelectedIndex = os.lpsVoiceSelect;

            txtVoiceLoidPathSofTalk.Text = os.lpsVoiceVRPathSofTalk;
            txtVoiceLoidPathYuduki.Text = os.lpsVoiceVRPathYukari;
            txtVoiceLoidPathTomoe.Text = os.lpsVoiceVRPathTomoe;
            txtVoiceLoidPathZunko.Text = os.lpsVoiceVRPathZunko;
            txtVoiceLoidPathYudukiEx.Text = os.lpsVoiceVRPathYukariEx;
            txtVoiceLoidPathTomoeEx.Text = os.lpsVoiceVRPathTomoeEx;
            txtVoiceLoidPathZunkoEx.Text = os.lpsVoiceVRPathZunkoEx;
            txtVoiceLoidPathAkane.Text = os.lpsVoiceVRPathAkane;
            txtVoiceLoidPathAoi.Text = os.lpsVoiceVRPathAoi;
        }
        #endregion

        /// <summary>
        /// setWindowImage
        /// ウインドウイメージをセットする
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="window"></param>
        #region setWindowImage
        private void setWindowImage(RadioButton rb, PictureBox pic, int window)
        {
            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(os.getWindowPath(window)))
            {
                rb.Enabled = false;
                pic.Enabled = false;
                return;
            }
            else if (os.getWindowPath(window).EndsWith(LiplisDefine.LPS_WINDOW_DEFAULT))
            {
                rb.Enabled = false;
                pic.Enabled = false;
                return;
            }

            Bitmap canvas = new Bitmap(pic.Width, pic.Height);

            using (Bitmap image = new Bitmap(os.getWindowPath(window)))
            {
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, 0, 0, 96, 42);

                }
            }

            pic.Image = canvas;
        }
        #endregion


        ///====================================================================
        ///
        ///                             onDelete
        ///                         
        ///====================================================================

        /// <summary>
        /// onDelete
        /// </summary>
        #region Dispose
        public void dispose()
        {
            flgEnd = true;
            this.Close();
        }
        #endregion

        /// <summary>
        /// onDelete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region ActivityRss_FormClosing
        private void ActivitySetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            //エンドフラグが有効でなければ、ハイドさせる
            if (!flgEnd)
            {
                e.Cancel = true;
                Invoke(new LpsDelegate.dlgVoidToVoid(this.Hide));
            }
        }
        #endregion

        ///====================================================================
        ///
        ///                             onLoad
        ///                         
        ///====================================================================

        /// <summary>
        /// ActivitySetting_Load
        /// onLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region ActivitySetting_Load
        private void ActivitySetting_Load(object sender, EventArgs e)
        {
            setBackgournd();
        }
        #endregion

        /// <summary>
        /// setBackgournd
        /// 背景をセットする
        /// </summary>
        #region setBackgournd
        private void setBackgournd()
        {
            this.BackgroundImage = owf.bt_setting;
        }
        #endregion

        ///====================================================================
        ///
        ///                            onRecive
        ///                         
        ///====================================================================

        /// <summary>
        /// onRecive
        /// </summary>
        #region onRecive
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 環境設定切り替え
        /// </summary>
        private void onEnvironment()
        {
            grpSetActive.Visible   = true;
            grpSetting.Visible     = true;
            grpWindow.Visible      = true;
            grpVoice.Visible       = false;
            grpSynchronism.Visible = false;
        }

        /// <summary>
        /// 環境設定切り替え
        /// </summary>
        private void onVoice()
        {
            grpSetActive.Visible   = false;
            grpSetting.Visible     = false;
            grpWindow.Visible      = false;
            grpVoice.Visible       = true;
            grpSynchronism.Visible = false;
        }

        private void btnJumpRss_Click(object sender, EventArgs e)
        {
            lips.onRecive(LiplisDefine.LM_RSS, "");
        }

        private void btnJumpTwitter_Click(object sender, EventArgs e)
        {
            lips.onRecive(LiplisDefine.LM_TWITTER, "");
        }

        private void btnJumpFilter_Click(object sender, EventArgs e)
        {
            lips.onRecive(LiplisDefine.LM_FILTER, "");
        }

        private void btnTwitterRegist_Click(object sender, EventArgs e)
        {
            lips.onRecive(LiplisDefine.LM_TWT_ACT, "");
        }

        private void btnOntimePassIssue_Click(object sender, EventArgs e)
        {
            checkOutOneTimePass();
        }

        private void btnOntimePass_Click(object sender, EventArgs e)
        {
            setUserId();
        }

        private void tsmHelpLiplisWindows_Click(object sender, EventArgs e)
        {
            dlgCallBrowser(LiplisDefine.LIPLIS_HELP);
        }

        private void tsmHelpLipliStyle_Click(object sender, EventArgs e)
        {
            dlgCallBrowser(LiplisDefine.LIPLIS_LIPLISTYLE);
        }
        #endregion

        ///====================================================================
        ///
        ///                            設定切り替え
        ///                         
        ///====================================================================
        #region 設定切り替え
        /// <summary>
        /// 環境設定呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnvironment_Click(object sender, EventArgs e)
        {
            onEnvironment();
        }
        /// <summary>
        /// 音声設定呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoice_Click(object sender, EventArgs e)
        {
            onVoice();
        }

        #endregion

        ///====================================================================
        ///
        ///                            モード変更
        ///                         
        ///====================================================================
        #region setting モード変更
        protected void setMode(int mode)
        {
            os.setMode(mode);
            savePreference();
            lips.onRecive(LiplisDefine.LM_LOAD_SETTING, LiplisDefine.LMP_NONOP);
            lips.onRecive(LiplisDefine.LM_CHANGE_MODE, "");
        }
        #endregion

        ///====================================================================
        ///
        ///                            スピード変更
        ///                         
        ///====================================================================
        #region setting スピード変更
        private void rboOtenba_CheckedChanged(object sender, EventArgs e)
        {
            if(flgLoad && rboOtenba.Checked)
            {
                trackSpeed.Value = reversePercent(100);
                setSpeed();
            }
        }

        private void rboNormal_CheckedChanged(object sender, EventArgs e)
        {
            if(flgLoad && rboNormal.Checked)
            {
                trackSpeed.Value = reversePercent(75);
                setSpeed();
            }
        }

        private void rboLittleYukkuri_CheckedChanged(object sender, EventArgs e)
        {
            if (flgLoad && rboLittleYukkuri.Checked)
            {
                trackSpeed.Value = 50;
                setSpeed();
            }  
        }

        private void rboYukkuri_CheckedChanged(object sender, EventArgs e)
        {
            if (flgLoad && rboYukkuri.Checked)
            {
                trackSpeed.Value = reversePercent(24);
                setSpeed();
            }   
        }

        private void rboEco_CheckedChanged(object sender, EventArgs e)
        {
            if (flgLoad && rboEco.Checked)
            {
                trackSpeed.Value = reversePercent(0);
                setSpeed();
            }
        }



        private void trackSpeed_Scroll(object sender, EventArgs e)
        {
            if(flgLoad)
            {
                setSpeed();

                if (os.lpsReftesh == 0)
                {
                    rboEco.Checked = true;

                }
                else if (os.lpsReftesh <= 24)
                {
                    rboYukkuri.Checked = true;
                }
                else if (os.lpsReftesh <= 50)
                {
                    rboLittleYukkuri.Checked = true;
                }
                else if (os.lpsReftesh <= 75)
                {
                    rboNormal.Checked = true;
                }
                else
                {
                    rboOtenba.Checked = true;
                }
            }
        }

        private void setSpeed()
        {
            os.setSpeed(reversePercent(trackSpeed.Value));
            txtSpeed.Text = os.lpsReftesh.ToString();
            savePreference();
            lips.onRecive(LiplisDefine.LM_LOAD_SETTING, LiplisDefine.LMP_NONOP);
            lips.onRecive(LiplisDefine.LM_CHANGE_SPEED, "");
        }

        private void txtSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (flgLoad)
            {
                if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }

                if (flgLoad)
                {
                    try
                    {
                        if (Int32.Parse(txtSpeed.Text) < 0)
                        {
                            txtSpeed.Text = "0";
                        }
                        else if (Int32.Parse(txtSpeed.Text) > 100)
                        {
                            txtSpeed.Text = "100";
                        }

                        trackSpeed.Value = reversePercent(Int32.Parse(txtSpeed.Text));
                        setSpeed();

                    }
                    catch
                    {

                    }
                }
            }
            
        }

        /// <summary>
        /// 100分率を反転して返す
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private Int32 reversePercent(Int32 val)
        {
            return 100-val;
        }

        #endregion

        /// <summary>
        /// 通常化
        /// </summary>
        #region onNormalize
        public void onNormalize()
        {
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        /// <summary>
        /// 最小化
        /// </summary>
        #region onMinimize
        public void onMinimize()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


        ///====================================================================
        ///
        ///                        ウインドウ関連
        ///                         
        ///====================================================================

        #region ウインドウ関連
        private void rbWindow1_CheckedChanged(object sender, EventArgs e)
        {
            setWindow(0);
        }

        private void rbWindow2_CheckedChanged(object sender, EventArgs e)
        {
            setWindow(1);
        }

        private void rbWindow3_CheckedChanged(object sender, EventArgs e)
        {
            setWindow(2);
        }

        private void rbWindow4_CheckedChanged(object sender, EventArgs e)
        {
            setWindow(3);
        }

        private void rbWindow5_CheckedChanged(object sender, EventArgs e)
        {
            setWindow(4);
        }

        private void rbWindow6_CheckedChanged(object sender, EventArgs e)
        {
            setWindow(5);
        }

        private void rbWindow7_CheckedChanged(object sender, EventArgs e)
        {
            setWindow(6);
        }

        private void picWindow1_Click(object sender, EventArgs e)
        {
            setWindow(0);
            rbWindow1.Checked = true;
        }

        private void picWindow2_Click(object sender, EventArgs e)
        {
            setWindow(1);
            rbWindow2.Checked = true;
        }

        private void picWindow3_Click(object sender, EventArgs e)
        {
            setWindow(2);
            rbWindow3.Checked = true;
        }

        private void picWindow4_Click(object sender, EventArgs e)
        {
            setWindow(3);
            rbWindow4.Checked = true;
        }

        private void picWindow5_Click(object sender, EventArgs e)
        {
            setWindow(4);
            rbWindow5.Checked = true;
        }

        private void picWindow6_Click(object sender, EventArgs e)
        {
            setWindow(5);
            rbWindow6.Checked = true;
        }

        private void picWindow7_Click(object sender, EventArgs e)
        {
            setWindow(6);
            rbWindow7.Checked = true;
        }

        private void setWindow(int window)
        {
            os.window = window;
            savePreference();
            lips.changeWindow();
        }
        #endregion


        ///====================================================================
        ///
        ///                               設定
        ///                         
        ///====================================================================

        #region 設定
        private void chkWindowChase_CheckedChanged(object sender, EventArgs e)
        {
            os.talkChase = LpsLiplisUtil.boolToBit(chkWindowChase.Checked);
            savePreference();
        }
        #endregion

        ///====================================================================
        ///
        ///                             音声設定
        ///                         
        ///====================================================================

        #region 音声設定
        private void chkVoice_CheckedChanged(object sender, EventArgs e)
        {
            os.lpsVoiceOn = LpsLiplisUtil.boolToBit(chkVoice.Checked);
            savePreference();
        }

        private void cmbVoiceSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!flgLoad) { return; }

            int selectedIdx = cmbVoiceSelect.SelectedIndex;

            switch(selectedIdx)
            {
                case 0:
                    break;
                case 1://ソフトーク
                    if (os.lpsVoiceVRPathSofTalk.Equals(""))
                    {
                        LpsLiplisUtil.LiplisMessageOkOnly("SofTalkのパスが設定されていません。");
                        cmbVoiceSelect.SelectedIndex = 0;
                    }
                    break;
                case 2://結月ゆかり
                    if (os.lpsVoiceVRPathYukari.Equals(""))
                    {
                        LpsLiplisUtil.LiplisMessageOkOnly("VOICEROID+ 結月ゆかりのパスが設定されていません。");
                        cmbVoiceSelect.SelectedIndex = 0;
                    }
                    break;
                case 3://民安ともえ
                    if (os.lpsVoiceVRPathTomoe.Equals(""))
                    {
                        LpsLiplisUtil.LiplisMessageOkOnly("VOICEROID+ 民安ともえのパスが設定されていません。");
                        cmbVoiceSelect.SelectedIndex = 0;
                    }
                    break;
                case 4://東北ずん子
                    if (os.lpsVoiceVRPathZunko.Equals(""))
                    {
                        LpsLiplisUtil.LiplisMessageOkOnly("VOICEROID+ 東北ずん子のパスが設定されていません。");
                        cmbVoiceSelect.SelectedIndex = 0;
                    }
                    break;
                case 5://結月ゆかりEX
                    if (os.lpsVoiceVRPathYukariEx.Equals(""))
                    {
                        LpsLiplisUtil.LiplisMessageOkOnly("VOICEROID+ 結月ゆかり EXのパスが設定されていません。");
                        cmbVoiceSelect.SelectedIndex = 0;
                    }
                    break;
                case 6://琴葉茜
                    if (os.lpsVoiceVRPathAkane.Equals(""))
                    {
                        LpsLiplisUtil.LiplisMessageOkOnly("VOICEROID+ 琴葉茜のパスが設定されていません。");
                        cmbVoiceSelect.SelectedIndex = 0;
                    }
                    break;
                case 7://琴葉葵
                    if (os.lpsVoiceVRPathAoi.Equals(""))
                    {
                        LpsLiplisUtil.LiplisMessageOkOnly("VOICEROID+ 琴葉葵のパスが設定されていません。");
                        cmbVoiceSelect.SelectedIndex = 0;
                    }
                    break;
                default:
                    break;
            }

            //セーブする
            os.lpsVoiceSelect = selectedIdx;
            savePreference();

            //ボイスロイドのインスタンスを作成し直す
            lips.onRecive(LiplisDefine.LM_RELOAD_VOICELOID, "");
        }

        private void btnVoiceLoidPathSofTalk_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("SofTalk", "SofTalk.exe");

            //ファイル名チェック
            if(filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathSofTalk.Text = filePath;
            os.lpsVoiceVRPathSofTalk = filePath;
            savePreference();
        }

        private void btnVoiceLoidPathYuduki_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 結月ゆかり", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathYuduki.Text = filePath;
            os.lpsVoiceVRPathYukari = filePath;
            savePreference();
        }

        private void btnVoiceLoidPathTomoe_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 民安ともえ", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathTomoe.Text = filePath;
            os.lpsVoiceVRPathTomoe = filePath;
            savePreference();
        }

        private void btnVoiceLoidPathZunko_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 東北ずん子", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathZunko.Text = filePath;
            os.lpsVoiceVRPathZunko = filePath;
            savePreference();
        }


        private void btnVoiceLoidPathYudukiEx_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 結月ゆかり EX", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathYudukiEx.Text = filePath;
            os.lpsVoiceVRPathYukariEx = filePath;
            savePreference();
        }

        private void btnVoiceLoidPathTomoeEx_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 民安ともえ EX", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathTomoeEx.Text = filePath;
            os.lpsVoiceVRPathTomoeEx = filePath;
            savePreference();
        }

        private void btnVoiceLoidPathZunkoEx_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 東北ずん子 EX", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathZunkoEx.Text = filePath;
            os.lpsVoiceVRPathZunkoEx = filePath;
            savePreference();
        }



        private void btnVoiceLoidPathAkane_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 琴葉茜", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathAkane.Text = filePath;
            os.lpsVoiceVRPathAkane = filePath;
            savePreference();
        }

        private void btnVoiceLoidPathAoi_Click(object sender, EventArgs e)
        {
            //ファイル名取得
            string filePath = getVRPath("VOICEROID+ 琴葉葵", "VOICEROID.exe");

            //ファイル名チェック
            if (filePath.Equals(""))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("ファイルが選択されませんでした。");
                return;
            }

            //存在チェック
            if (!LpsLiplisUtil.ExistsFile(filePath))
            {
                LpsLiplisUtil.LiplisMessageOkOnly("対象のファイルは存在しません！");
                return;
            }

            //OKならプリファレンスに記録してテキストに表示
            txtVoiceLoidPathAoi.Text = filePath;
            os.lpsVoiceVRPathAoi = filePath;
            savePreference();
        }

        #endregion

        /// <summary>
        /// ボイスロイドパスを設定する
        /// /summary>
        #region getVRPath
        private string getVRPath(string title, string defaultExeName)
        {
            try
            {
                //OpenFileDialogクラスのインスタンスを作成
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.FileName = defaultExeName;
                ofd.InitialDirectory = @"C:\";
                ofd.Filter = "音声エンジン実行ファイル(*.exe)|*.exe";
                ofd.FilterIndex = 0;
                ofd.Title = title + "の実行ファイルを指定してください。";
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }

                return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion
        

        ///====================================================================
        ///
        ///                             同期関連
        ///                         
        ///====================================================================

        /// <summary>
        /// checkOutOneTimePass
        /// </summary>
        #region checkOutOneTimePass
        private void checkOutOneTimePass()
        {
            //ワンタイムパスワード取得
            ResUserOnetimePass res = LiplisApiCus.getOneTimePass(os.uid);

            //ワンタイムパスワードのセット
            txtOneTimePass.Text = res.oneTimePass;
        }
        #endregion
        
        /// <summary>
        /// setUserId
        /// ユーザーIDを上書きする
        /// </summary>
        #region setUserId
        private void setUserId()
        {
            //ワンタイムパスワード取得
            ResLiplisId res = LiplisApiCus.getLiplisId(txtOtherPass.Text);

            //ユーザーIDの取得チェック
            if (res.userId.Equals(""))
            {
                MessageBox.Show("ユーザーIDの取得に失敗しました。" + Environment.NewLine + "ワンタイムパスワードを確認してください。" + Environment.NewLine + "ワンタイムパスワードを再取得して下さい。", "Liplis");
                return;
            }

            //最終確認
            if (MessageBox.Show("ユーザーIDを更新しますが、よろしいでしょうか？", "Liplis", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                //ユーザーID変更履歴の出力
                try { System.IO.File.AppendAllText(LpsPathController.getSettingPath() + DateTime.Now.ToString("yyyyMMddhhmmss") + "userPassChange.log", res.userId, Encoding.GetEncoding(932)); }
                catch
                {}

                //ユーザーIDの上書き
                os.uid = res.userId;
                savePreference();

                MessageBox.Show("ユーザーIDを更新しました。", "Liplis");
            }
        }
        #endregion
        

        ///====================================================================
        ///
        ///                       ウインドウ制御
        ///                         
        ///====================================================================

        /// <summary>
        /// setBackGround
        /// 背景のセット
        /// </summary>
        #region setBackGround
        public void setBackGround(Bitmap bmp)
        {
            reqSetBackGround(bmp);
        }
        #endregion

        ///====================================================================
        ///
        ///                       メニュー操作
        ///                         
        ///====================================================================

        /// <summary>
        /// tsmSave_Click
        /// 保存クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region tsmSave_Click
        private void tsmSave_Click(object sender, EventArgs e)
        {
            savePreference();
        }
        #endregion

        /// <summary>
        /// デフォルトに戻すクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region tsmDefault_Click
        private void tsmDefault_Click(object sender, EventArgs e)
        {

            if (LpsLiplisUtil.LiplisMessage("設定をデフォルトに戻しますか？"))
            {
                //UIDの保存
                string uid = os.uid;

                //ロードデフォルト
                os.loadDefault();

                //UIDの復元
                os.uid = uid;

                //設定の初期化
                initSetting();
            }
        }
        #endregion

        /// <summary>
        /// tsmVersion_Click
        /// バージョン情報
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region tsmVersion_Click
        private void tsmVersion_Click(object sender, EventArgs e)
        {
            using (ActivityVersion f = new ActivityVersion(this.Left + this.Width/2, this.Top + this.Height/2))
            {
                f.ShowDialog();
            }
        }
        #endregion

        ///====================================================================
        ///
        ///                       デリゲート
        ///                         
        ///====================================================================

        /// <summary>
        /// dlgSetBackGround
        /// 背景を設定する
        /// </summary>
        #region dlgSetBackGround
        private void dlgSetBackGround(Bitmap bmp)
        {
            this.BackgroundImage = bmp;
        }
        #endregion

        /// <summary>
        /// ブラウザをコールする
        /// </summary>
        #region dlgCallBrowser
        private void dlgCallBrowser(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (System.ComponentModel.Win32Exception fileNotFoundErr)
            {
                Console.Write(fileNotFoundErr);
                //lips.chatFixedSentence(ComDefine.err_BrowzerErr);
                //lips.expression = ComDefine.EXPRESSION_CRY;
            }
            catch (System.Exception err)
            {
                Console.Write(err);
            }
        }
        #endregion


        ///====================================================================
        ///
        ///                             設定保存
        ///                         
        ///====================================================================
        
        /// <summary>
        /// プリファレンスデータをセーブする
        /// 2014/01/14 Liplis3.2.2 起動時はセーブ処理しない
        /// </summary>
        #region savePreference
        private void savePreference()
        {
            if (this.flgLoad)
            {
                os.setPreferenceData();
            }
        }
        #endregion

        ///====================================================================
        ///
        ///                          話題のリロード
        ///                         
        ///====================================================================
        #region 話題のリロード
        /// <summary>
        /// 話題のリロード
        /// </summary>
        private void reloadTopic()
        {
            if (!flgLoad) { return; }
            lips.onRecive(LiplisDefine.LM_TOPIC_RELOAD, "");
        }


        #endregion


    }
}
