using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Cursors = System.Windows.Forms.Cursors;

namespace @try
{
    public partial class Form1 : Form
    {
        int shape = 0;
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        int width = 0;
        int hight = 0;
        bool erase = false;
        int size = 1;
        Graphics g;
        Pen p;

        public Form1()
        {
            InitializeComponent();
            g = Document.CreateGraphics();
            p = new Pen(Color.Black , size);
        }
        #region Editor and General 
        private void Timer_Tick_1(object sender, EventArgs e)
        {
            charCount.Text = "Characters in the current document: " + Document.TextLength.ToString();
            status_ZoomFactor.Text = Document.ZoomFactor.ToString();
        }
        #endregion
        #region MainMenu 
        #endregion
        #region Toolbar
        void FontSize()
        {
            for (int fntSize = 10; fntSize <= 75; fntSize++)
            {
                tb_FontSize.Items.Add(fntSize.ToString());
            }
        }

        void InstalledFonts()
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            for (int i = 0; i < fonts.Families.Length; i++)
            {
                tb_Font.Items.Add(fonts.Families[i].Name);
            }
        }
        #endregion
        #region contextmenu 
        #endregion
        #region Methods 
        #endregion

        #region file 
        void New()
        {
            Document.Clear();
        }

        void Open()
        {
            if (openWork.ShowDialog() == DialogResult.OK)
            {
                Document.LoadFile(openWork.FileName, RichTextBoxStreamType.PlainText);
            }
        }



        void Save()
        {
            if (saveWork.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document.SaveFile(saveWork.FileName, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        void Exit()
        {
            Application.Exit();
        }

        #endregion
        #region edit 
        void Undo()
        {
            Document.Undo();
        }

        void Redo()
        {
            Document.Redo();
        }

        void Cut()
        {
            Document.Cut();
        }

        void Copy()
        {
            Document.Copy();
        }

        void Paste()
        {
            Document.Paste();
        }

        void SelectAll()
        {
            Document.SelectAll();
        }

        void ClearAll()
        {
            Document.Clear();
        }
        #endregion
        #region tools 
        void customise()
        {
            ColorDialog myDialog = new ColorDialog();
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                mainMenu.BackColor = myDialog.Color;
                Status.BackColor = myDialog.Color;
                Tools.BackColor = myDialog.Color;
            }
        }

        #endregion
        private void TextEditor_Load(object sender, EventArgs e)
        {
            FontSize();
            InstalledFonts();
        }

        private void tb_New_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tb_Open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tb_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void edit_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void edit_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void edit_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void edit_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void edit_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void edit_SelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void tools_Customisation_Click(object sender, EventArgs e)
        {
            customise();
        }

        private void tb_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void tb_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void tb_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void tb_ZoomIn_Click(object sender, EventArgs e)
        {
            if (Document.ZoomFactor == 63)
            {
                return;
            }
            else
            {
                Document.ZoomFactor = Document.ZoomFactor + 1;
            }
        }

        private void tb_ZoomOut_Click(object sender, EventArgs e)
        {
            if (Document.ZoomFactor == 1)
            {
                return;
            }
            else
                Document.ZoomFactor = Document.ZoomFactor - 1;
        }



        private void tb_Bold_Click(object sender, EventArgs e)
        {
            Font bfont = new Font(Document.Font, FontStyle.Bold);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Bold)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = bfont;
            }
        }

        private void tb_Italic_Click(object sender, EventArgs e)
        {
            Font Ifont = new Font(Document.Font, FontStyle.Italic);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Italic)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = Ifont;
            }
        }

        private void tb_UnderLine_Click(object sender, EventArgs e)
        {
            Font Ufont = new Font(Document.Font, FontStyle.Underline);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Underline)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = Ufont;
            }
        }

        private void tb_Strike_Click(object sender, EventArgs e)
        {
            Font Sfont = new Font(Document.Font, FontStyle.Strikeout);
            Font rfont = new Font(Document.Font, FontStyle.Regular);
            if (Document.SelectedText.Length == 0)
                return;
            if (Document.SelectionFont.Strikeout)
            {
                Document.SelectionFont = rfont;
            }
            else
            {
                Document.SelectionFont = Sfont;
            }
        }

        private void tb_AlignLeft_Click(object sender, EventArgs e)
        {
            Document.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void tb_AlignCenter_Click(object sender, EventArgs e)
        {
            Document.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void tb_AlignRight_Click(object sender, EventArgs e)
        {
            Document.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Document.SelectedText = Document.SelectedText.ToUpper();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Document.SelectedText = Document.SelectedText.ToLower();
        }

        private void tb_Font_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Drawing.Font ComboFonts = null;
            try
            {
                ComboFonts = Document.SelectionFont;
                Document.SelectionFont = new System.Drawing.Font(tb_Font.Text, Document.SelectionFont.Size, Document.SelectionFont.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_FontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Document.SelectionFont = new Font(tb_FontSize.SelectedItem.ToString(),
                int.Parse(tb_FontSize.SelectedItem.ToString()),
                Document.SelectionFont.Style);
        }

        private void Document_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void undowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Document_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        //********************************************************************************************************************

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 1;
            Document.Cursor = Cursors.Cross;
        }

        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 2;
            Document.Cursor = Cursors.Cross;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 3;
            Document.Cursor = Cursors.Cross;
        }

        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 4;
            Document.Cursor = Cursors.Cross;
        }

        private void Document_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            width = x2 - x1;
            hight = y2 - y1;
            p.Color = Color.Black;
            switch(shape)
            {
                case 1: g.DrawRectangle(p, x1, y1, width, hight); break;
                case 2: g.DrawEllipse(p, x1, y1, width, hight); break;
                case 3: g.DrawLine(p, x1, y1, x2, y2); break;
                case 4: erase = false; break;
                case 5: SolidBrush b = new SolidBrush(Color.Black);
                    g.DrawString(drawstring.Text, Document.Font, b, x1, y1);
                    break;
                case 6:
                    Bitmap b1 = new Bitmap("car.png");
                    g.DrawImage(b1, new Rectangle(x1, y1, width, hight));
                    break;
            }
        }

        private void Document_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            if (shape == 4)
                erase = true;
        }

        private void Document_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (erase)
            {
                p.Color = Color.White;
                g.DrawEllipse(p, e.X, e.Y, 15, 15);
            }
        }

        private void drawTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 5;
        }

        private void incresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            size = size + 1;
            p = new Pen(Color.Black, size);
        }

        private void reduceSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (size != 1)
            {
                size = size - 1;
                p = new Pen(Color.Black, size);
            }
        }

        private void drowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 6;
            Document.Cursor = Cursors.Cross;
        }

        private void file_Open_Click(object sender, EventArgs e)
        {
            Open();
        }
    }
}
