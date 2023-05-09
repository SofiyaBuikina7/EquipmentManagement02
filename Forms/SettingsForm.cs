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
            EvenForeColorTb.BackColor = EvenRowDisplayTb.ForeColor;
            EvenBackColorTb.BackColor = EvenRowDisplayTb.BackColor;
            OddForeColorTb.BackColor = OddRowDisplayTb.ForeColor;
            OddBackColorTb.BackColor = OddRowDisplayTb.BackColor;
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

        private void ApplyLicenseBtn_Click(object sender, EventArgs e) {
            Settings.CurrentSettings.EvenForeColor = EvenRowDisplayTb.ForeColor;
            Settings.CurrentSettings.EvenBackColor = EvenRowDisplayTb.BackColor;
            Settings.CurrentSettings.OddForeColor = OddRowDisplayTb.ForeColor;
            Settings.CurrentSettings.OddBackColor = OddRowDisplayTb.BackColor;
            Settings.CurrentSettings.TableFont = EvenRowDisplayTb.Font;
            Settings.CurrentSettings.SaveSettings();

        }
    }

}
