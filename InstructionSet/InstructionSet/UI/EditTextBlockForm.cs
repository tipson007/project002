using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstructionSet.Models;
using InstructionSet.Models.Decorators;

namespace InstructionSet.UI
{
    public partial class EditTextBlockForm : Form
    {
        private string initialText;
        private PlainTextBlock plainTextBlock;
        private TextBlock textBlock;
        private Font defaultFont;

        public TextBlock Result { get; private set; }

        public EditTextBlockForm(TextBlock tb, Font font)
        {
            defaultFont = font;
            textBlock = tb;
            plainTextBlock = TextBlockUtil.FindPlainTextBox(tb);
            InitializeComponent();
            initialText = plainTextBlock.Text;
            rtbEntry.Text = initialText;
            chbUnderline.CheckedChanged -= ChbUnderline_CheckedChanged;           
            var underlineDec = TextBlockDecorator.FindDecorator<UnderlineDecorator>(tb);
            if(underlineDec == null)
            {
                chbUnderline.Checked = false;                
            } else
            {
                chbUnderline.Checked = (underlineDec.Underline == UnderlineDecorator.UnderlineType.Single);                
            }
            chbUnderline.CheckedChanged += ChbUnderline_CheckedChanged;            
            UpdateView();
            rtbEntry.Focus();
        }

        private void UpdateView()
        {
            var context = new RtfContext();
            context.AddFont(defaultFont.Name);
            var rtfBody = textBlock.ToRtf(context);            
            rtbText.Rtf = $@"{context.RtfHeader}{{\pard {rtfBody}\par}}}}";          
        }       

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Result = textBlock;
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            plainTextBlock.Text = initialText;
            DialogResult = DialogResult.Cancel;
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            var fontDec = TextBlockDecorator.FindDecorator<FontDecorator>(textBlock);
            fontDialog.Font = fontDec?.Font ?? defaultFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (fontDec != null) fontDec.Font = fontDialog.Font;
                else
                {
                    textBlock = new FontDecorator(textBlock, fontDialog.Font);
                }
            }
            UpdateView();
        }

        private void BtnPenColor_Click(object sender, EventArgs e)
        {
            var fcolDec = TextBlockDecorator.FindDecorator<ForeColorDecorator>(textBlock);
            colorDialog.Color = fcolDec?.ForeColor ?? Color.Black;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (fcolDec != null) fcolDec.ForeColor = colorDialog.Color;
                else
                {
                    textBlock = new ForeColorDecorator(textBlock, colorDialog.Color);
                }
            }
            UpdateView();
        }

        private void BtnBackColor_Click(object sender, EventArgs e)
        {
            var bcolDec = TextBlockDecorator.FindDecorator<BackColorDecorator>(textBlock);
            colorDialog.Color = bcolDec?.BackColor ?? Color.White;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (bcolDec != null) bcolDec.BackColor = colorDialog.Color;
                else
                {
                    textBlock = new BackColorDecorator(textBlock, colorDialog.Color);
                }
            }
            UpdateView();
        }

        private void ChbUnderline_CheckedChanged(object sender, EventArgs e)
        {            
            var underlineDec = TextBlockDecorator.FindDecorator<UnderlineDecorator>(textBlock);
            if (underlineDec != null)
            {
                underlineDec.Underline = chbUnderline.Checked ?
                    UnderlineDecorator.UnderlineType.Single : UnderlineDecorator.UnderlineType.None;
            }
            else
            {
                textBlock = new UnderlineDecorator(textBlock, chbUnderline.Checked ?
                    UnderlineDecorator.UnderlineType.Single : UnderlineDecorator.UnderlineType.None);
            }
            UpdateView();
        }     

        private void RtbEntry_TextChanged(object sender, EventArgs e)
        {           
            plainTextBlock.Text = rtbEntry.Text;
            UpdateView();
        }        
    }
}
