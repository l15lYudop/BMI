using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class frmBMI : Form
    {
        public frmBMI()
        {
            InitializeComponent();
            // 註冊按鈕事件
            this.btnRun.Click += btnRun_Click;
        }

        private void lblBMI_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // 取得並驗證輸入
            if (!double.TryParse(txtHeight.Text.Trim(), out double heightCm) || heightCm <= 0)
            {
                MessageBox.Show("請輸入有效的身高（公分）。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeight.Focus();
                return;
            }

            if (!double.TryParse(txtWeight.Text.Trim(), out double weightKg) || weightKg <= 0)
            {
                MessageBox.Show("請輸入有效的體重（公斤）。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWeight.Focus();
                return;
            }

            // 計算 BMI
            double heightM = heightCm / 100.0;
            double bmi = weightKg / (heightM * heightM);
            double bmiRounded = Math.Round(bmi, 1);

            // 判斷分類與顏色
            string category = GetBmiCategory(bmi);
            Color color = GetCategoryColor(category);

            // 顯示結果
            lblResult.Text = $"{bmiRounded} — {category}";
            lblResult.ForeColor = color;
        }

        private string GetBmiCategory(double bmi)
        {
            // 使用 WHO 常見分級（可依需求調整）
            if (bmi < 18.5) return "過輕";
            if (bmi < 25.0) return "正常";
            if (bmi < 30.0) return "過重";
            return "肥胖";
        }

        private Color GetCategoryColor(string category)
        {
            switch (category)
            {
                case "過輕": return Color.DodgerBlue;
                case "正常": return Color.Green;
                case "過重": return Color.Orange;
                case "肥胖": return Color.Red;
                default: return Color.Black;
            }
        }
    }
}
