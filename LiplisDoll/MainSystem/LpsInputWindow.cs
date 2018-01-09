//=======================================================================
//  ClassName : InputWindow
// ■概要      : LiplisDollのメインクラス
//
// Copyright(c) 2014 LipliStyle さちん MITライセンス
//=======================================================================
using Liplis.Activity;
using Liplis.Common;
using Liplis.Msg;
using Liplis.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Liplis.MainSystem
{
    public partial class LpsInputWindow : Form
    {
        ///=====================================
        /// リプリス
        private Liplis lips;
        private ObjSetting os;
        private ObjSkinSetting oss;

        ///=====================================
        /// 現在セット中のおしゃべり情報
        protected MsgShortNews liplisNowTopic;
        protected Color nowColor = Color.White;

        ///=====================================
        /// 制御フラグ
        private bool flgDgvUpdate = false;

        ///====================================================================
        ///
        ///                            初期化処理
        ///                         
        ///====================================================================
        #region 初期化処理
        public LpsInputWindow(Liplis lips, ObjSetting os, ObjSkinSetting oss)
        {
            this.lips = lips;
            this.os = os;
            this.oss = oss;
            InitializeComponent();
            initWindow();
        }

        /// <summary>
        /// ウインドウの初期化
        /// </summary>
        private void initWindow()
        {
            dgvEmotionSetting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmotionSetting.RowHeadersVisible = false;
            btnSend.Enabled = false;
            btnStop.Enabled = false;
        }
        #endregion


        ///====================================================================
        ///
        ///                            onRecive
        ///                         
        ///====================================================================
        #region onRecive

        /// <summary>
        /// おしゃべり内容送信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = true;

            //ノーマライズ
            lips.setObjectBodyNeutral();

            if (liplisNowTopic != null)
            {
                this.lips.talk(liplisNowTopic);
            }
            else
            {
                this.lips.talk(txtInput.Text,0);
            }
        }

        /// <summary>
        /// おしゃべり停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.lips.onRecive(LiplisDefine.LM_CHANGE_STOP, "");
            btnStop.Enabled = false;
            btnSend.Enabled = true;
        }

        /// <summary>
        /// クリアボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }

        /// <summary>
        /// クリアボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// エモーション付与押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmotion_Click(object sender, EventArgs e)
        {
            setEmotion();
        }

        /// <summary>
        /// 分かち書き
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWakachi_Click(object sender, EventArgs e)
        {
            setWakachi();
        }

        /// <summary>
        /// 終了ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// フォーム閉じ自Liplis終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LpsInputWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
            Application.Exit();
        }

        /// <summary>
        /// データグリッドバリデート
        /// 文字をはじく
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmotionSetting_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(!flgDgvUpdate)
            {
                dgvCheck((DataGridView)sender, e);
            }
        }

        /// <summary>
        /// データグリッド入力内容変化時
        /// DGVの文字色変更、ニュースオブジェクトの再生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmotionSetting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //dgv再チェック
            dgvColorWidthCheck();

            //再クリエイト
            reCreateLpsNews();
        }

        /// <summary>
        /// データグリッドセルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmotionSetting_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //右クリックのときのみ
            if (e.Button == MouseButtons.Right)
            {
                //コンテキストメニューを表示する
                this.cmsDataGrid.Show();

                //マウスカーソルの位置を画面座標で取得
                Point p = MousePosition;
                this.cmsDataGrid.Top = p.Y;
                this.cmsDataGrid.Left = p.X;

                //メニューのタグに、クリックインデックスをセットする
                this.tsmiBr.Tag = e.ColumnIndex;
                this.tsmiNewCol.Tag = e.ColumnIndex;
                this.tsmiTagHr.Tag = e.ColumnIndex;
            }
        }

        /// <summary>
        /// ヘルプを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            dlgCallBrowser(LiplisDefine.LIPLIS_DOLL_HELP);
        }

        /// <summary>
        /// バージョンを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiVersion_Click(object sender, EventArgs e)
        {
            using (ActivityVersion f = new ActivityVersion(this.Left + this.Width / 2, this.Top + this.Height / 2))
            {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// 設定を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenSetting_Click(object sender, EventArgs e)
        {
            lips.onRecive(LiplisDefine.LM_SETTING,"");
        }

        /// <summary>
        /// 新規列挿入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiNewCol_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            insertNewColumn((int)tsmi.Tag, "","","");
        }

        /// <summary>
        /// 改行挿入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiBr_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            insertNewColumn((int)tsmi.Tag, "<br />", "", "");
        }


        private void tsmiTagHr_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            insertNewColumn((int)tsmi.Tag, "<hr />", "", "");
        }

        private void divToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertNewColumnRange("<div>", "</div>", "0", "0");
        }

        private void spanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertNewColumnRange("<span>", "</span>", "0", "0");
        }

        private void tsmiStringSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            insertNewColumnRange("<font size=\"" + tsmi.Text + "\">", "</font>", "0", "0");
        }

        private void tsmiStringColor_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            insertNewColumnRange("<font color=\"" + tsmi.Tag.ToString() + "\">", "</font>", "0", "0");
        }

        private void tsmiStringBold_Click(object sender, EventArgs e)
        {
            insertNewColumnRange("<b>", "</b>", "0", "0");
        }

        private void tsmiStringItalic_Click(object sender, EventArgs e)
        {
            insertNewColumnRange("<i>", "</i>", "0", "0");
        }

        private void tsmiStringStrike_Click(object sender, EventArgs e)
        {
            insertNewColumnRange("<strike>", "</strike>", "0", "0");
        }

        private void dgvEmotionSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                deleteRange();
            }
        }
        #endregion


        ///====================================================================
        ///
        ///                         フォーム処理
        ///                         
        ///====================================================================
        #region フォーム処理

        /// <summary>
        /// エモーションセット
        /// </summary>
        private void setEmotion()
        {
            getClalisApiResult(0);
        }

        /// <summary>
        /// 分かち書きする
        /// </summary>
        private void setWakachi()
        {
            getClalisApiResult(1);
        }

        /// <summary>
        /// ClalisApiに投げた結果を得る
        /// </summary>
        /// <param name="mode"></param>
        private void getClalisApiResult(int mode)
        {
            string tone = "";

            //からチェック
            if(txtInput.Text == "")
            {
                return;
            }

            //口調変換チェック
            if (chkToneConvert.Checked)
            {
                tone = this.oss.toneUrl;
            }

            //感情値取得
            liplisNowTopic = LiplisApiCus.getFreeWord(this.txtInput.Text, tone);

            //セットする
            setDgv(mode);

            //おしゃべりボタンを有効化
            btnSend.Enabled = true;
        }

        /// <summary>
        /// 入力情報のクリア
        /// </summary>
        private void Clear()
        {
            //入力ボックス初期化
            txtInput.Text = "";

            //データグリッド初期化
            dgvEmotionSetting.Rows.Clear();
            dgvEmotionSetting.Columns.Clear();

            //ニュースオブジェクト初期化
            liplisNowTopic = new MsgShortNews();

            //グリッド背景カラー初期化
            nowColor = Color.White;

            //ノーマライズ
            lips.setObjectBodyNeutral();
            this.lips.onRecive(LiplisDefine.LM_CHANGE_STOP, "");

            //おしゃべりボタン無効
            btnSend.Enabled = false;
            btnStop.Enabled = false;
        }

        /// <summary>
        /// データグリッドセット
        /// mode : 0 感情付与　　　1 : 分かち書き
        /// </summary>
        private void setDgv(int mode)
        {
            try
            {
                //データグリッド初期化
                dgvEmotionSetting.Rows.Clear();
                dgvEmotionSetting.Columns.Clear();

                //作業用リスト
                List<string> emotionList = new List<string>();
                List<string> pointList = new List<string>();


                //要素数分の列を追加する
                foreach (var item in liplisNowTopic.nameList.Select((v, i) => new { v, i }))
                {
                    //行追加
                    addCols(item.i);
                    

                    ///モードによって感情値、ポイント付与
                    if (mode == 0)
                    {
                        //int配列をstringListに変換
                        pointList.Add(liplisNowTopic.pointList[item.i].ToString());
                        emotionList.Add(liplisNowTopic.emotionList[item.i].ToString());
                    }
                    else
                    {
                        emotionList.Add("0");
                        pointList.Add("0");
                    }                    
                }

                //nameListが0件以上であれば、データグリッドにセットする
                if(liplisNowTopic.nameList.Count > 0)
                {
                    dgvEmotionSetting.Rows.Add(liplisNowTopic.nameList.ToArray());
                    dgvEmotionSetting.Rows.Add(emotionList.ToArray());
                    dgvEmotionSetting.Rows.Add(pointList.ToArray());
                }

                //背景色の調整
                dgvColorWidthCheck();

                //業固定
                dgvEmotionSetting.Rows[0].Frozen = true;
                dgvEmotionSetting.Rows[1].Frozen = true;
                dgvEmotionSetting.Rows[2].Frozen = true;
            }
            catch
            {

            }
        }

        /// <summary>
        /// 幅調整と背景着色を行う。
        /// </summary>
        private void dgvColorWidthCheck()
        {
            if(dgvEmotionSetting.Rows.Count < 1)
            {
                return;
            }

            int idx = 0;

            //なうカラーの初期化
            nowColor = Color.White;

            //セルを回してチェック
            foreach (DataGridViewCell c in dgvEmotionSetting.Rows[0].Cells)
            {
                //背景色の変更
                cellColorChange(dgvEmotionSetting.Rows[1].Cells[idx], dgvEmotionSetting.Rows[2].Cells[idx]);
                idx++;
            }
        }
            
        /// <summary>
        /// データグリッドセルの背景色を変更する
        /// </summary>
        /// <param name="c"></param>
        private void cellColorChange(DataGridViewCell emo, DataGridViewCell point)
        {
            switch(int.Parse(emo.Value.ToString()))
            {
                case 0: break;
                case 1: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 255, 255, 153); } else { nowColor = Color.FromArgb(0, 204, 153, 255); } break;
                case 2: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 255, 85, 204); } else { nowColor = Color.FromArgb(0, 51, 102, 255); } break;
                case 3: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 204, 255, 204); } else { nowColor = Color.FromArgb(0, 72, 0, 255); } break;
                case 4: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 0, 255, 230); } else { nowColor = Color.FromArgb(0, 152, 0, 255); } break;
                case 5: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 255, 255, 0); } else { nowColor = Color.FromArgb(0, 160, 255, 0); } break;
                case 6: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 255, 0, 0); } else { nowColor = Color.FromArgb(0, 255, 90, 0); } break;
                case 7: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 255, 204, 0); } else { nowColor = Color.FromArgb(0, 128, 128, 128); } break;
                case 8: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 50, 150, 100); } else { nowColor = Color.FromArgb(0, 0, 0, 255); } break;
                case 9: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 0, 255, 255); } else { nowColor = Color.FromArgb(0, 128, 0, 0); } break;
                case 10: if (int.Parse(point.Value.ToString()) >= 0) { nowColor = Color.FromArgb(0, 128, 0, 0); } else { nowColor = Color.FromArgb(0, 255, 0, 90); } break;

                default:
                    break;
            }

            //背景色変更
            emo.Style.BackColor = Color.Black;
            emo.Style.SelectionBackColor = Color.Black;
            point.Style.BackColor = Color.Black;
            point.Style.SelectionBackColor = Color.Black;

            
            //emo.Style.Font = new Font(emo.Style.Font, FontStyle.Bold);
            emo.Style.ForeColor = nowColor;
            //point.Style.Font = new Font(point.Style.Font,FontStyle.Bold);
            point.Style.ForeColor = nowColor;

            //編集する
            //flgDgvUpdate = true;
            //dgvEmotionSetting.BeginEdit(false);
            //dgvEmotionSetting.CurrentCell = emo;
            //dgvEmotionSetting.EndEdit();
            //dgvEmotionSetting.BeginEdit(false);
            //dgvEmotionSetting.CurrentCell = point;
            //dgvEmotionSetting.EndEdit();
            //flgDgvUpdate = false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        private void addCols(int idx)
        {
            //DataGridViewTextBoxColumn列を作成する
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            //データソースの"Column1"をバインドする
            textColumn.DataPropertyName = idx.ToString();
            //名前とヘッダーを設定する
            textColumn.Name = idx.ToString();
            textColumn.HeaderText = idx.ToString();

            //ソート不可
            textColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            //列を追加する
            dgvEmotionSetting.Columns.Add(textColumn);
        }

        /// <summary>
        /// ニューカラムを挿入する
        /// </summary>
        /// <param name="insertIdx"></param>
        /// <param name="name"></param>
        /// <param name="emotion"></param>
        /// <param name="point"></param>
        private void insertNewColumn(int insertIdx, string name, string emotion, string point)
        {
            try
            {
                //スクロール量を保持しておく
                int scroll = dgvEmotionSetting.HorizontalScrollingOffset;

                //データグリッド初期化
                dgvEmotionSetting.Rows.Clear();
                dgvEmotionSetting.Columns.Clear();

                //作業用リスト
                List<string> newNameList = new List<string>();
                List<string> newEmotionList = new List<string>();
                List<string> newPointList = new List<string>();

                //カウント用インデックス
                int idx = 0;


                //要素数分の列を追加する
                foreach (var item in liplisNowTopic.nameList.Select((v, i) => new { v, i }))
                {
                    //指定位置への列挿入
                    if (item.i == insertIdx)
                    {
                        //行追加
                        addCols(idx);

                        //int配列をstringListに変換
                        newNameList.Add(name);
                        newPointList.Add("0");
                        newEmotionList.Add("0");

                        idx++;
                    }

                    //行追加
                    addCols(idx);


                    //int配列をstringListに変換
                    newNameList.Add(item.v);
                    newPointList.Add(liplisNowTopic.pointList[item.i].ToString());
                    newEmotionList.Add(liplisNowTopic.emotionList[item.i].ToString());

                    idx++;
                }

                //nameListが0件以上であれば、データグリッドにセットする
                if (liplisNowTopic.nameList.Count > 0)
                {
                    dgvEmotionSetting.Rows.Add(newNameList.ToArray());
                    dgvEmotionSetting.Rows.Add(newEmotionList.ToArray());
                    dgvEmotionSetting.Rows.Add(newPointList.ToArray());
                }

                //背景色の調整
                dgvColorWidthCheck();

                //業固定
                dgvEmotionSetting.Rows[0].Frozen = true;
                dgvEmotionSetting.Rows[1].Frozen = true;
                dgvEmotionSetting.Rows[2].Frozen = true;

                //メッセージりクリエイト
                reCreateLpsNews();

                //スクロール移動
                dgvEmotionSetting.HorizontalScrollingOffset = scroll;
            }
            catch
            {

            }
        }

        /// <summary>
        /// ニューカラムを挿入する
        /// </summary>
        /// <param name="insertIdx"></param>
        /// <param name="name"></param>
        /// <param name="emotion"></param>
        /// <param name="point"></param>
        private void insertNewColumnRange(string startTag, string endTag, string emotion, string point)
        {
            try
            {
                ///選択チェック
                if (dgvEmotionSetting.SelectedCells.Count == 0)
                {
                    MessageBox.Show("列を選択してから、操作を行ってください。", "LiplisDoll");
                    return;
                }

                //スクロール量を保持しておく
                int scroll = dgvEmotionSetting.HorizontalScrollingOffset;

                //作業用リスト
                List<string> newNameList = new List<string>();
                List<string> newEmotionList = new List<string>();
                List<string> newPointList = new List<string>();

                //カウント用インデックス
                int idx = 0;
                int idxMax = 0;
                int idxMin = 999999999;

                //最大、最少を取得する
                foreach(DataGridViewCell c in dgvEmotionSetting.SelectedCells)
                {
                    if(c.ColumnIndex >= idxMax)
                    {
                        idxMax = c.ColumnIndex + 1;
                    }
                    if(c.ColumnIndex <= idxMin)
                    {
                        idxMin = c.ColumnIndex;
                    }
                }


                //データグリッド初期化
                dgvEmotionSetting.Rows.Clear();
                dgvEmotionSetting.Columns.Clear();


                //要素数分の列を追加する
                foreach (var item in liplisNowTopic.nameList.Select((v, i) => new { v, i }))
                {
                    //開始位置に挿入
                    if (item.i == idxMin)
                    {
                        //行追加
                        addCols(idx);

                        //int配列をstringListに変換
                        newNameList.Add(startTag);
                        newPointList.Add("0");
                        newEmotionList.Add("0");

                        idx++;
                    }

                    //終了位置に挿入
                    if (item.i == idxMax)
                    {
                        //行追加
                        addCols(idx);

                        //int配列をstringListに変換
                        newNameList.Add(endTag);
                        newPointList.Add("0");
                        newEmotionList.Add("0");

                        idx++;
                    }

                    //行追加
                    addCols(idx);


                    //int配列をstringListに変換
                    newNameList.Add(item.v);
                    newPointList.Add(liplisNowTopic.pointList[item.i].ToString());
                    newEmotionList.Add(liplisNowTopic.emotionList[item.i].ToString());

                    idx++;
                }

                //nameListが0件以上であれば、データグリッドにセットする
                if (liplisNowTopic.nameList.Count > 0)
                {
                    dgvEmotionSetting.Rows.Add(newNameList.ToArray());
                    dgvEmotionSetting.Rows.Add(newEmotionList.ToArray());
                    dgvEmotionSetting.Rows.Add(newPointList.ToArray());
                }

                //背景色の調整
                dgvColorWidthCheck();

                //業固定
                dgvEmotionSetting.Rows[0].Frozen = true;
                dgvEmotionSetting.Rows[1].Frozen = true;
                dgvEmotionSetting.Rows[2].Frozen = true;

                //メッセージりクリエイト
                reCreateLpsNews();

                //スクロール移動
                dgvEmotionSetting.HorizontalScrollingOffset = scroll;
            }
            catch
            {

            }
        }

        /// <summary>
        /// 選択行を削除する
        /// </summary>
        private void deleteRange()
        {
            try
            {
                ///選択チェック
                if (dgvEmotionSetting.SelectedCells.Count == 0)
                {
                    MessageBox.Show("列を選択してから、操作を行ってください。", "LiplisDoll");
                    return;
                }


                List<DataGridViewColumn> selectedList = new List<DataGridViewColumn>();
                //カウント用インデックス
                int idxMax = 0;
                int idxMin = 999999999;

                //最大、最少を取得する
                foreach (DataGridViewCell c in dgvEmotionSetting.SelectedCells)
                {
                    if (c.ColumnIndex >= idxMax)
                    {
                        idxMax = c.ColumnIndex;
                    }
                    if (c.ColumnIndex <= idxMin)
                    {
                        idxMin = c.ColumnIndex;
                    }
                }

                //選択状態にする
                foreach(DataGridViewColumn c in dgvEmotionSetting.Columns)
                {
                    if(c.Index　>=　idxMin && c.Index <= idxMax)
                    {
                        c.Selected = true;
                        selectedList.Add(c);
                    }
                }

                ///削除
                foreach (DataGridViewColumn c in selectedList)
                {
                    dgvEmotionSetting.Columns.Remove(c);
                    c.Dispose();
                }

                //クリア
                selectedList.Clear();

                //メッセージりクリエイト
                reCreateLpsNews();
            }
            catch
            {

            }
        }


        /// <summary>
        /// dvgチェック
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        private void dgvCheck(DataGridView dgv, DataGridViewCellValidatingEventArgs e)
        {
            //新しい行のセルでなく、セルの内容が変更されている時だけ検証する
            if (e.RowIndex == dgv.NewRowIndex || !dgv.IsCurrentCellDirty)
            {
                return;
            }

            ///数値チェック
            if(e.RowIndex == 1 || e.RowIndex == 2)
            {
                try
                {
                    //数値検査
                    int.Parse(e.FormattedValue.ToString());
                }
                catch
                {
                    //数値以外の入力の場合はスルー
                    dgv.CancelEdit();
                    return;
                }
            }
        }

        /// <summary>
        /// データグリッドデータからニュースメッセージを再生成する。
        /// </summary>
        private void reCreateLpsNews()
        {
            int idx = 0;
            StringBuilder result = new StringBuilder();
            MsgShortNews newLiplisNowTopic = new MsgShortNews();

            foreach (DataGridViewCell c in dgvEmotionSetting.Rows[0].Cells)
            {
                newLiplisNowTopic.nameList.Add(LpsLiplisUtil.nullCheck(c.Value).ToString());
                newLiplisNowTopic.emotionList.Add(int.Parse(LpsLiplisUtil.nullCheck(dgvEmotionSetting.Rows[1].Cells[idx].Value).ToString()));
                newLiplisNowTopic.pointList.Add(int.Parse(LpsLiplisUtil.nullCheck(dgvEmotionSetting.Rows[2].Cells[idx].Value).ToString()));

                result.Append(LpsLiplisUtil.nullCheck(c.Value).ToString());
                idx++;
            }

            newLiplisNowTopic.result = result.ToString();
            newLiplisNowTopic.sorce = result.ToString();
            newLiplisNowTopic.title = result.ToString();

            //セット
            liplisNowTopic = newLiplisNowTopic;
        }



        #endregion



        ///====================================================================
        ///
        ///                       デリゲート
        ///                         
        ///====================================================================

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


    }
}
