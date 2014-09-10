using System;

namespace _1calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelWithTextBox = new System.Windows.Forms.TableLayoutPanel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelWithButtons = new System.Windows.Forms.TableLayoutPanel();
            this.groupButton = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelWithTextBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelWithTextBox
            // 
            this.tableLayoutPanelWithTextBox.ColumnCount = 1;
            this.tableLayoutPanelWithTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWithTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWithTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWithTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWithTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWithTextBox.Controls.Add(this.textBox, 0, 0);
            this.tableLayoutPanelWithTextBox.Controls.Add(this.tableLayoutPanelWithButtons, 0, 1);
            this.tableLayoutPanelWithTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWithTextBox.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelWithTextBox.Name = "tableLayoutPanelWithTextBox";
            this.tableLayoutPanelWithTextBox.RowCount = 2;
            this.tableLayoutPanelWithTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelWithTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelWithTextBox.Size = new System.Drawing.Size(274, 242);
            this.tableLayoutPanelWithTextBox.TabIndex = 0;
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(3, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(268, 30);
            this.textBox.TabIndex = 0;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanelWithButtons
            // 
            this.tableLayoutPanelWithButtons.ColumnCount = 5;
            this.tableLayoutPanelWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelWithButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelWithButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWithButtons.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelWithButtons.Name = "tableLayoutPanelWithButtons";
            this.tableLayoutPanelWithButtons.RowCount = 3;
            this.tableLayoutPanelWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelWithButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelWithButtons.Size = new System.Drawing.Size(268, 176);
            this.tableLayoutPanelWithButtons.TabIndex = 1;
            // 
            // groupButton
            // 
            this.groupButton.Location = new System.Drawing.Point(0, 0);
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(200, 100);
            this.groupButton.TabIndex = 0;
            this.groupButton.TabStop = false;

            InitializeMyGroupBox();
            calculator = new Calculator();
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 242);
            this.Controls.Add(this.tableLayoutPanelWithTextBox);
            this.MaximumSize = new System.Drawing.Size(290, 280);
            this.MinimumSize = new System.Drawing.Size(290, 280);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.tableLayoutPanelWithTextBox.ResumeLayout(false);
            this.tableLayoutPanelWithTextBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWithTextBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWithButtons;
        private System.Windows.Forms.GroupBox groupButton;
        private Calculator calculator;
    }
}

