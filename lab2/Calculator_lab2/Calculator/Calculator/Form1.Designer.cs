namespace Calculator
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addition = new System.Windows.Forms.Button();
            this.subtraction = new System.Windows.Forms.Button();
            this.multiplication = new System.Windows.Forms.Button();
            this.division = new System.Windows.Forms.Button();
            this.Number1 = new System.Windows.Forms.Button();
            this.Number2 = new System.Windows.Forms.Button();
            this.Number3 = new System.Windows.Forms.Button();
            this.Number4 = new System.Windows.Forms.Button();
            this.Number5 = new System.Windows.Forms.Button();
            this.Number6 = new System.Windows.Forms.Button();
            this.Number7 = new System.Windows.Forms.Button();
            this.Number8 = new System.Windows.Forms.Button();
            this.Number9 = new System.Windows.Forms.Button();
            this.Number0 = new System.Windows.Forms.Button();
            this.decimalPoint = new System.Windows.Forms.Button();
            this.equals = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // addition
            // 
            resources.ApplyResources(this.addition, "addition");
            this.addition.Name = "addition";
            this.addition.UseVisualStyleBackColor = true;
            this.addition.Click += new System.EventHandler(this.addition_Click);
            // 
            // subtraction
            // 
            resources.ApplyResources(this.subtraction, "subtraction");
            this.subtraction.Name = "subtraction";
            this.subtraction.UseVisualStyleBackColor = true;
            this.subtraction.Click += new System.EventHandler(this.subtraction_Click);
            // 
            // multiplication
            // 
            resources.ApplyResources(this.multiplication, "multiplication");
            this.multiplication.Name = "multiplication";
            this.multiplication.UseVisualStyleBackColor = true;
            this.multiplication.Click += new System.EventHandler(this.multiplication_Click);
            // 
            // division
            // 
            resources.ApplyResources(this.division, "division");
            this.division.Name = "division";
            this.division.UseVisualStyleBackColor = true;
            this.division.Click += new System.EventHandler(this.division_Click);
            // 
            // Number1
            // 
            resources.ApplyResources(this.Number1, "Number1");
            this.Number1.Name = "Number1";
            this.Number1.UseVisualStyleBackColor = true;
            this.Number1.Click += new System.EventHandler(this.Number1_Click);
            // 
            // Number2
            // 
            resources.ApplyResources(this.Number2, "Number2");
            this.Number2.Name = "Number2";
            this.Number2.UseVisualStyleBackColor = true;
            this.Number2.Click += new System.EventHandler(this.Number2_Click);
            // 
            // Number3
            // 
            resources.ApplyResources(this.Number3, "Number3");
            this.Number3.Name = "Number3";
            this.Number3.UseVisualStyleBackColor = true;
            this.Number3.Click += new System.EventHandler(this.Number3_Click);
            // 
            // Number4
            // 
            resources.ApplyResources(this.Number4, "Number4");
            this.Number4.Name = "Number4";
            this.Number4.UseVisualStyleBackColor = true;
            this.Number4.Click += new System.EventHandler(this.Number4_Click);
            // 
            // Number5
            // 
            resources.ApplyResources(this.Number5, "Number5");
            this.Number5.Name = "Number5";
            this.Number5.UseVisualStyleBackColor = true;
            this.Number5.Click += new System.EventHandler(this.Number5_Click);
            // 
            // Number6
            // 
            resources.ApplyResources(this.Number6, "Number6");
            this.Number6.Name = "Number6";
            this.Number6.UseVisualStyleBackColor = true;
            this.Number6.Click += new System.EventHandler(this.Number6_Click);
            // 
            // Number7
            // 
            resources.ApplyResources(this.Number7, "Number7");
            this.Number7.Name = "Number7";
            this.Number7.UseVisualStyleBackColor = true;
            this.Number7.Click += new System.EventHandler(this.Number7_Click);
            // 
            // Number8
            // 
            resources.ApplyResources(this.Number8, "Number8");
            this.Number8.Name = "Number8";
            this.Number8.UseVisualStyleBackColor = true;
            this.Number8.Click += new System.EventHandler(this.Number8_Click);
            // 
            // Number9
            // 
            resources.ApplyResources(this.Number9, "Number9");
            this.Number9.Name = "Number9";
            this.Number9.UseVisualStyleBackColor = true;
            this.Number9.Click += new System.EventHandler(this.Number9_Click);
            // 
            // Number0
            // 
            resources.ApplyResources(this.Number0, "Number0");
            this.Number0.Name = "Number0";
            this.Number0.UseVisualStyleBackColor = true;
            this.Number0.Click += new System.EventHandler(this.Number0_Click);
            // 
            // decimalPoint
            // 
            resources.ApplyResources(this.decimalPoint, "decimalPoint");
            this.decimalPoint.Name = "decimalPoint";
            this.decimalPoint.UseVisualStyleBackColor = true;
            this.decimalPoint.Click += new System.EventHandler(this.decimalPoint_Click);
            // 
            // equals
            // 
            resources.ApplyResources(this.equals, "equals");
            this.equals.Name = "equals";
            this.equals.UseVisualStyleBackColor = true;
            this.equals.Click += new System.EventHandler(this.equals_Click);
            // 
            // Clear
            // 
            resources.ApplyResources(this.Clear, "Clear");
            this.Clear.Name = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.equals);
            this.Controls.Add(this.decimalPoint);
            this.Controls.Add(this.Number0);
            this.Controls.Add(this.Number9);
            this.Controls.Add(this.Number8);
            this.Controls.Add(this.Number7);
            this.Controls.Add(this.Number6);
            this.Controls.Add(this.Number5);
            this.Controls.Add(this.Number4);
            this.Controls.Add(this.Number3);
            this.Controls.Add(this.Number2);
            this.Controls.Add(this.Number1);
            this.Controls.Add(this.division);
            this.Controls.Add(this.multiplication);
            this.Controls.Add(this.subtraction);
            this.Controls.Add(this.addition);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button addition;
		private System.Windows.Forms.Button subtraction;
		private System.Windows.Forms.Button multiplication;
		private System.Windows.Forms.Button division;
		private System.Windows.Forms.Button Number1;
		private System.Windows.Forms.Button Number2;
		private System.Windows.Forms.Button Number3;
		private System.Windows.Forms.Button Number4;
		private System.Windows.Forms.Button Number5;
		private System.Windows.Forms.Button Number6;
		private System.Windows.Forms.Button Number7;
		private System.Windows.Forms.Button Number8;
		private System.Windows.Forms.Button Number9;
		private System.Windows.Forms.Button Number0;
		private System.Windows.Forms.Button decimalPoint;
		private System.Windows.Forms.Button equals;
		private System.Windows.Forms.Button Clear;
	}
}

