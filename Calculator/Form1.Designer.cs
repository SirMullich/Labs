namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.display = new System.Windows.Forms.TextBox();
            this.Pad1 = new System.Windows.Forms.Button();
            this.Pad2 = new System.Windows.Forms.Button();
            this.Pad3 = new System.Windows.Forms.Button();
            this.Pad8 = new System.Windows.Forms.Button();
            this.Pad9 = new System.Windows.Forms.Button();
            this.Pad0 = new System.Windows.Forms.Button();
            this.Pad7 = new System.Windows.Forms.Button();
            this.Pad5 = new System.Windows.Forms.Button();
            this.Pad4 = new System.Windows.Forms.Button();
            this.Pad6 = new System.Windows.Forms.Button();
            this.operationMultiply = new System.Windows.Forms.Button();
            this.operationSubstract = new System.Windows.Forms.Button();
            this.operationAddition = new System.Windows.Forms.Button();
            this.operationDivision = new System.Windows.Forms.Button();
            this.operationChangeSign = new System.Windows.Forms.Button();
            this.operationPoint = new System.Windows.Forms.Button();
            this.operationResult = new System.Windows.Forms.Button();
            this.operationSquareRoot = new System.Windows.Forms.Button();
            this.operationMC = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.display.Location = new System.Drawing.Point(78, 43);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(264, 32);
            this.display.TabIndex = 0;
            this.display.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Pad1
            // 
            this.Pad1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad1.Location = new System.Drawing.Point(132, 243);
            this.Pad1.Name = "Pad1";
            this.Pad1.Size = new System.Drawing.Size(48, 48);
            this.Pad1.TabIndex = 1;
            this.Pad1.Text = "1";
            this.Pad1.UseVisualStyleBackColor = true;
            this.Pad1.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad2
            // 
            this.Pad2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad2.Location = new System.Drawing.Point(186, 243);
            this.Pad2.Name = "Pad2";
            this.Pad2.Size = new System.Drawing.Size(48, 48);
            this.Pad2.TabIndex = 2;
            this.Pad2.Text = "2";
            this.Pad2.UseVisualStyleBackColor = true;
            this.Pad2.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad3
            // 
            this.Pad3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad3.Location = new System.Drawing.Point(240, 243);
            this.Pad3.Name = "Pad3";
            this.Pad3.Size = new System.Drawing.Size(48, 48);
            this.Pad3.TabIndex = 3;
            this.Pad3.Text = "3";
            this.Pad3.UseVisualStyleBackColor = true;
            this.Pad3.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad8
            // 
            this.Pad8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad8.Location = new System.Drawing.Point(186, 135);
            this.Pad8.Name = "Pad8";
            this.Pad8.Size = new System.Drawing.Size(48, 48);
            this.Pad8.TabIndex = 4;
            this.Pad8.Text = "8";
            this.Pad8.UseVisualStyleBackColor = true;
            this.Pad8.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad9
            // 
            this.Pad9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad9.Location = new System.Drawing.Point(240, 135);
            this.Pad9.Name = "Pad9";
            this.Pad9.Size = new System.Drawing.Size(48, 48);
            this.Pad9.TabIndex = 5;
            this.Pad9.Text = "9";
            this.Pad9.UseVisualStyleBackColor = true;
            this.Pad9.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad0
            // 
            this.Pad0.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad0.Location = new System.Drawing.Point(132, 297);
            this.Pad0.Name = "Pad0";
            this.Pad0.Size = new System.Drawing.Size(48, 48);
            this.Pad0.TabIndex = 6;
            this.Pad0.Text = "0";
            this.Pad0.UseVisualStyleBackColor = true;
            this.Pad0.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad7
            // 
            this.Pad7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad7.Location = new System.Drawing.Point(132, 135);
            this.Pad7.Name = "Pad7";
            this.Pad7.Size = new System.Drawing.Size(48, 48);
            this.Pad7.TabIndex = 7;
            this.Pad7.Text = "7";
            this.Pad7.UseVisualStyleBackColor = true;
            this.Pad7.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad5
            // 
            this.Pad5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad5.Location = new System.Drawing.Point(186, 189);
            this.Pad5.Name = "Pad5";
            this.Pad5.Size = new System.Drawing.Size(48, 48);
            this.Pad5.TabIndex = 8;
            this.Pad5.Text = "5";
            this.Pad5.UseVisualStyleBackColor = true;
            this.Pad5.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad4
            // 
            this.Pad4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad4.Location = new System.Drawing.Point(132, 189);
            this.Pad4.Name = "Pad4";
            this.Pad4.Size = new System.Drawing.Size(48, 48);
            this.Pad4.TabIndex = 9;
            this.Pad4.Text = "4";
            this.Pad4.UseVisualStyleBackColor = true;
            this.Pad4.Click += new System.EventHandler(this.pad_Click);
            // 
            // Pad6
            // 
            this.Pad6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pad6.Location = new System.Drawing.Point(240, 189);
            this.Pad6.Name = "Pad6";
            this.Pad6.Size = new System.Drawing.Size(48, 48);
            this.Pad6.TabIndex = 10;
            this.Pad6.Text = "6";
            this.Pad6.UseVisualStyleBackColor = true;
            this.Pad6.Click += new System.EventHandler(this.pad_Click);
            // 
            // operationMultiply
            // 
            this.operationMultiply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationMultiply.Location = new System.Drawing.Point(294, 189);
            this.operationMultiply.Name = "operationMultiply";
            this.operationMultiply.Size = new System.Drawing.Size(48, 48);
            this.operationMultiply.TabIndex = 11;
            this.operationMultiply.Text = "*";
            this.operationMultiply.UseVisualStyleBackColor = true;
            this.operationMultiply.Click += new System.EventHandler(this.operation_Click);
            // 
            // operationSubstract
            // 
            this.operationSubstract.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationSubstract.Location = new System.Drawing.Point(294, 243);
            this.operationSubstract.Name = "operationSubstract";
            this.operationSubstract.Size = new System.Drawing.Size(48, 48);
            this.operationSubstract.TabIndex = 12;
            this.operationSubstract.Text = "-";
            this.operationSubstract.UseVisualStyleBackColor = true;
            this.operationSubstract.Click += new System.EventHandler(this.operation_Click);
            // 
            // operationAddition
            // 
            this.operationAddition.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationAddition.Location = new System.Drawing.Point(294, 297);
            this.operationAddition.Name = "operationAddition";
            this.operationAddition.Size = new System.Drawing.Size(48, 48);
            this.operationAddition.TabIndex = 13;
            this.operationAddition.Text = "+";
            this.operationAddition.UseVisualStyleBackColor = true;
            this.operationAddition.Click += new System.EventHandler(this.operation_Click);
            // 
            // operationDivision
            // 
            this.operationDivision.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationDivision.Location = new System.Drawing.Point(294, 135);
            this.operationDivision.Name = "operationDivision";
            this.operationDivision.Size = new System.Drawing.Size(48, 48);
            this.operationDivision.TabIndex = 14;
            this.operationDivision.Text = "/";
            this.operationDivision.UseVisualStyleBackColor = true;
            this.operationDivision.Click += new System.EventHandler(this.operation_Click);
            // 
            // operationChangeSign
            // 
            this.operationChangeSign.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationChangeSign.Location = new System.Drawing.Point(186, 297);
            this.operationChangeSign.Name = "operationChangeSign";
            this.operationChangeSign.Size = new System.Drawing.Size(48, 48);
            this.operationChangeSign.TabIndex = 15;
            this.operationChangeSign.Text = "+/-";
            this.operationChangeSign.UseVisualStyleBackColor = true;
            // 
            // operationPoint
            // 
            this.operationPoint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationPoint.Location = new System.Drawing.Point(240, 297);
            this.operationPoint.Name = "operationPoint";
            this.operationPoint.Size = new System.Drawing.Size(48, 48);
            this.operationPoint.TabIndex = 16;
            this.operationPoint.Text = ".";
            this.operationPoint.UseVisualStyleBackColor = true;
            this.operationPoint.Click += new System.EventHandler(this.functionality_Click);
            // 
            // operationResult
            // 
            this.operationResult.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationResult.Location = new System.Drawing.Point(348, 297);
            this.operationResult.Name = "operationResult";
            this.operationResult.Size = new System.Drawing.Size(48, 48);
            this.operationResult.TabIndex = 17;
            this.operationResult.Text = "=";
            this.operationResult.UseVisualStyleBackColor = true;
            this.operationResult.Click += new System.EventHandler(this.operationResult_Click);
            // 
            // operationSquareRoot
            // 
            this.operationSquareRoot.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationSquareRoot.Location = new System.Drawing.Point(348, 135);
            this.operationSquareRoot.Name = "operationSquareRoot";
            this.operationSquareRoot.Size = new System.Drawing.Size(48, 48);
            this.operationSquareRoot.TabIndex = 18;
            this.operationSquareRoot.Text = "sqrt";
            this.operationSquareRoot.UseVisualStyleBackColor = true;
            this.operationSquareRoot.Click += new System.EventHandler(this.operation_Click);
            // 
            // operationMC
            // 
            this.operationMC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationMC.Location = new System.Drawing.Point(78, 135);
            this.operationMC.Name = "operationMC";
            this.operationMC.Size = new System.Drawing.Size(48, 48);
            this.operationMC.TabIndex = 19;
            this.operationMC.Text = "MC";
            this.operationMC.UseVisualStyleBackColor = true;
            this.operationMC.Click += new System.EventHandler(this.functionality_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(78, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 20;
            this.button2.Text = "MR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.functionality_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(78, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 48);
            this.button3.TabIndex = 21;
            this.button3.Text = "MS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.functionality_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(78, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 48);
            this.button4.TabIndex = 22;
            this.button4.Text = "M+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.functionality_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(78, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 48);
            this.button1.TabIndex = 23;
            this.button1.Text = "C";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.functionality_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(170, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 48);
            this.button5.TabIndex = 24;
            this.button5.Text = "CE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.functionality_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(252, 81);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 48);
            this.button6.TabIndex = 25;
            this.button6.Text = "Back";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.functionality_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(348, 189);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 48);
            this.button7.TabIndex = 26;
            this.button7.Text = "%";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.percent_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(348, 243);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(48, 48);
            this.button8.TabIndex = 27;
            this.button8.Text = "1/x";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.functionality_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.operationMC);
            this.Controls.Add(this.operationSquareRoot);
            this.Controls.Add(this.operationResult);
            this.Controls.Add(this.operationPoint);
            this.Controls.Add(this.operationChangeSign);
            this.Controls.Add(this.operationDivision);
            this.Controls.Add(this.operationAddition);
            this.Controls.Add(this.operationSubstract);
            this.Controls.Add(this.operationMultiply);
            this.Controls.Add(this.Pad6);
            this.Controls.Add(this.Pad4);
            this.Controls.Add(this.Pad5);
            this.Controls.Add(this.Pad7);
            this.Controls.Add(this.Pad0);
            this.Controls.Add(this.Pad9);
            this.Controls.Add(this.Pad8);
            this.Controls.Add(this.Pad3);
            this.Controls.Add(this.Pad2);
            this.Controls.Add(this.Pad1);
            this.Controls.Add(this.display);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.Button Pad1;
        private System.Windows.Forms.Button Pad2;
        private System.Windows.Forms.Button Pad3;
        private System.Windows.Forms.Button Pad8;
        private System.Windows.Forms.Button Pad9;
        private System.Windows.Forms.Button Pad0;
        private System.Windows.Forms.Button Pad7;
        private System.Windows.Forms.Button Pad5;
        private System.Windows.Forms.Button Pad4;
        private System.Windows.Forms.Button Pad6;
        private System.Windows.Forms.Button operationMultiply;
        private System.Windows.Forms.Button operationSubstract;
        private System.Windows.Forms.Button operationAddition;
        private System.Windows.Forms.Button operationDivision;
        private System.Windows.Forms.Button operationChangeSign;
        private System.Windows.Forms.Button operationPoint;
        private System.Windows.Forms.Button operationResult;
        private System.Windows.Forms.Button operationSquareRoot;
        private System.Windows.Forms.Button operationMC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

