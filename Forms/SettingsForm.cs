using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentManagement.Forms {

    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();

            if (Settings.CurrentSettings.TableFont != null) {
                EvenRowDisplayTb.Text = GetFontString(Settings.CurrentSettings.TableFont);
                EvenRowDisplayTb.Font = Settings.CurrentSettings.TableFont;
            } else {
                EvenRowDisplayTb.Text = GetFontString(EvenRowDisplayTb.Font);
            }
            OddRowDisplayTb.Text = EvenRowDisplayTb.Text;
            OddRowDisplayTb.Font = EvenRowDisplayTb.Font;
            BadRowDisplayTb.Text = EvenRowDisplayTb.Text;
            BadRowDisplayTb.Font = EvenRowDisplayTb.Font;



            if (Settings.CurrentSettings.EvenForeColor != null) {
                EvenRowDisplayTb.ForeColor = Settings.CurrentSettings.EvenForeColor;
            }
            if (Settings.CurrentSettings.EvenBackColor != null) {
                EvenRowDisplayTb.BackColor = Settings.CurrentSettings.EvenBackColor;
            }
            if (Settings.CurrentSettings.OddForeColor != null) {
                OddRowDisplayTb.ForeColor = Settings.CurrentSettings.OddForeColor;
            }
            if (Settings.CurrentSettings.OddBackColor != null) {
                OddRowDisplayTb.BackColor = Settings.CurrentSettings.OddBackColor;
            }
            if (Settings.CurrentSettings.BadForeColor != null) {
                BadRowDisplayTb.ForeColor = Settings.CurrentSettings.BadForeColor;
            }
            if (Settings.CurrentSettings.BadBackColor != null) {
                BadRowDisplayTb.BackColor = Settings.CurrentSettings.BadBackColor;
            }
            EvenForeColorTb.BackColor = EvenRowDisplayTb.ForeColor;
            EvenBackColorTb.BackColor = EvenRowDisplayTb.BackColor;
            OddForeColorTb.BackColor = OddRowDisplayTb.ForeColor;
            OddBackColorTb.BackColor = OddRowDisplayTb.BackColor;
            BadForeColorTb.BackColor = BadRowDisplayTb.ForeColor;
            BadBackColorTb.BackColor = BadRowDisplayTb.BackColor;
        }

   
        string GetFontString(Font font) {
            return font.Name + ";" + font.Size.ToString() + ";";
        }

        private void ChoseFontBtn_Click(object sender, EventArgs e) {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK) {
                EvenRowDisplayTb.Text = GetFontString(fontDialog.Font);
                EvenRowDisplayTb.Font = fontDialog.Font;
                OddRowDisplayTb.Text = EvenRowDisplayTb.Text;
                OddRowDisplayTb.Font = EvenRowDisplayTb.Font;
                BadRowDisplayTb.Text = EvenRowDisplayTb.Text;
                BadRowDisplayTb.Font = EvenRowDisplayTb.Font;
            }
        }

        private void EvenForeColorTb_DoubleClick(object sender, EventArgs e) {
            SetColor(sender, ref EvenRowDisplayTb, true);
        }

        private void EvenBackColorTb_DoubleClick(object sender, EventArgs e) {
            SetColor(sender, ref EvenRowDisplayTb, false);
        }

        private void OddForeColorTb_DoubleClick(object sender, EventArgs e) {
            SetColor(sender, ref OddRowDisplayTb, true);
        }

        private void OddBackColorTb_DoubleClick(object sender, EventArgs e) {
            SetColor(sender, ref OddRowDisplayTb, false);
        }

        private void BadForeColorTb_DoubleClick(object sender, EventArgs e) {
            SetColor(sender, ref BadRowDisplayTb, true);
        }

        private void BadBackColorTb_DoubleClick(object sender, EventArgs e) {
            SetColor(sender, ref BadRowDisplayTb, false);
        }

        void SetColor(object sender, ref TextBox textBox, bool fore) {
            ColorDialog colorDialog = new ColorDialog();
            var MySender = (TextBox)sender;
            colorDialog.Color = MySender.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                MySender.BackColor = colorDialog.Color;
                if (fore) {
                    textBox.ForeColor = MySender.BackColor;
                } else {
                    textBox.BackColor = MySender.BackColor;
                }
            }
        }


    }

}
