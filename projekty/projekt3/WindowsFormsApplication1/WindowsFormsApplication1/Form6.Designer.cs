namespace WindowsFormsApplication1
{
    partial class Form6
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
            this.carBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.customerBox = new System.Windows.Forms.ComboBox();
            this.carDealerBox = new System.Windows.Forms.ComboBox();
            this.dealerUpdate = new System.Windows.Forms.Button();
            this.customerUpdate = new System.Windows.Forms.Button();
            this.carUpdate = new System.Windows.Forms.Button();
            this.makeBox = new System.Windows.Forms.TextBox();
            this.name1Box = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.dealerNameBox = new System.Windows.Forms.TextBox();
            this.dealerTownBox = new System.Windows.Forms.TextBox();
            this.modelBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.capacityBox = new System.Windows.Forms.TextBox();
            this.custBox = new System.Windows.Forms.TextBox();
            this.dealerBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.namelast = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CarLoad = new System.Windows.Forms.Button();
            this.customerLoad = new System.Windows.Forms.Button();
            this.dealerLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // carBox
            // 
            this.carBox.FormattingEnabled = true;
            this.carBox.Location = new System.Drawing.Point(76, 229);
            this.carBox.Name = "carBox";
            this.carBox.Size = new System.Drawing.Size(121, 21);
            this.carBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // customerBox
            // 
            this.customerBox.FormattingEnabled = true;
            this.customerBox.Location = new System.Drawing.Point(264, 229);
            this.customerBox.Name = "customerBox";
            this.customerBox.Size = new System.Drawing.Size(121, 21);
            this.customerBox.TabIndex = 2;
            // 
            // carDealerBox
            // 
            this.carDealerBox.FormattingEnabled = true;
            this.carDealerBox.Location = new System.Drawing.Point(435, 229);
            this.carDealerBox.Name = "carDealerBox";
            this.carDealerBox.Size = new System.Drawing.Size(121, 21);
            this.carDealerBox.TabIndex = 3;
            // 
            // dealerUpdate
            // 
            this.dealerUpdate.Location = new System.Drawing.Point(435, 285);
            this.dealerUpdate.Name = "dealerUpdate";
            this.dealerUpdate.Size = new System.Drawing.Size(75, 23);
            this.dealerUpdate.TabIndex = 4;
            this.dealerUpdate.Text = "Update";
            this.dealerUpdate.UseVisualStyleBackColor = true;
            this.dealerUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // customerUpdate
            // 
            this.customerUpdate.Location = new System.Drawing.Point(264, 285);
            this.customerUpdate.Name = "customerUpdate";
            this.customerUpdate.Size = new System.Drawing.Size(75, 23);
            this.customerUpdate.TabIndex = 5;
            this.customerUpdate.Text = "Update";
            this.customerUpdate.UseVisualStyleBackColor = true;
            this.customerUpdate.Click += new System.EventHandler(this.button3_Click);
            // 
            // carUpdate
            // 
            this.carUpdate.Location = new System.Drawing.Point(76, 285);
            this.carUpdate.Name = "carUpdate";
            this.carUpdate.Size = new System.Drawing.Size(75, 23);
            this.carUpdate.TabIndex = 6;
            this.carUpdate.Text = "Update";
            this.carUpdate.UseVisualStyleBackColor = true;
            this.carUpdate.Click += new System.EventHandler(this.button4_Click);
            // 
            // makeBox
            // 
            this.makeBox.Location = new System.Drawing.Point(76, 57);
            this.makeBox.Name = "makeBox";
            this.makeBox.Size = new System.Drawing.Size(100, 20);
            this.makeBox.TabIndex = 7;
            // 
            // name1Box
            // 
            this.name1Box.Location = new System.Drawing.Point(262, 57);
            this.name1Box.Name = "name1Box";
            this.name1Box.Size = new System.Drawing.Size(100, 20);
            this.name1Box.TabIndex = 8;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(262, 83);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameBox.TabIndex = 9;
            // 
            // dealerNameBox
            // 
            this.dealerNameBox.Location = new System.Drawing.Point(436, 53);
            this.dealerNameBox.Name = "dealerNameBox";
            this.dealerNameBox.Size = new System.Drawing.Size(100, 20);
            this.dealerNameBox.TabIndex = 10;
            // 
            // dealerTownBox
            // 
            this.dealerTownBox.Location = new System.Drawing.Point(435, 79);
            this.dealerTownBox.Name = "dealerTownBox";
            this.dealerTownBox.Size = new System.Drawing.Size(100, 20);
            this.dealerTownBox.TabIndex = 11;
            // 
            // modelBox
            // 
            this.modelBox.Location = new System.Drawing.Point(76, 83);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(100, 20);
            this.modelBox.TabIndex = 12;
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(76, 109);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(100, 20);
            this.priceBox.TabIndex = 13;
            // 
            // capacityBox
            // 
            this.capacityBox.Location = new System.Drawing.Point(76, 135);
            this.capacityBox.Name = "capacityBox";
            this.capacityBox.Size = new System.Drawing.Size(100, 20);
            this.capacityBox.TabIndex = 14;
            // 
            // custBox
            // 
            this.custBox.Location = new System.Drawing.Point(76, 161);
            this.custBox.Name = "custBox";
            this.custBox.Size = new System.Drawing.Size(100, 20);
            this.custBox.TabIndex = 15;
            // 
            // dealerBox
            // 
            this.dealerBox.Location = new System.Drawing.Point(76, 187);
            this.dealerBox.Name = "dealerBox";
            this.dealerBox.Size = new System.Drawing.Size(100, 20);
            this.dealerBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // namelast
            // 
            this.namelast.AutoSize = true;
            this.namelast.Location = new System.Drawing.Point(198, 85);
            this.namelast.Name = "namelast";
            this.namelast.Size = new System.Drawing.Size(58, 13);
            this.namelast.TabIndex = 19;
            this.namelast.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Town";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Car dealer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Capacity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Customer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Model";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Make";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(258, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 33);
            this.label5.TabIndex = 28;
            this.label5.Text = "Update";
            // 
            // CarLoad
            // 
            this.CarLoad.Location = new System.Drawing.Point(76, 256);
            this.CarLoad.Name = "CarLoad";
            this.CarLoad.Size = new System.Drawing.Size(75, 23);
            this.CarLoad.TabIndex = 29;
            this.CarLoad.Text = "Load";
            this.CarLoad.UseVisualStyleBackColor = true;
            this.CarLoad.Click += new System.EventHandler(this.CarLoad_Click);
            // 
            // customerLoad
            // 
            this.customerLoad.Location = new System.Drawing.Point(264, 256);
            this.customerLoad.Name = "customerLoad";
            this.customerLoad.Size = new System.Drawing.Size(75, 23);
            this.customerLoad.TabIndex = 30;
            this.customerLoad.Text = "Load";
            this.customerLoad.UseVisualStyleBackColor = true;
            this.customerLoad.Click += new System.EventHandler(this.customerLoad_Click);
            // 
            // dealerLoad
            // 
            this.dealerLoad.Location = new System.Drawing.Point(435, 256);
            this.dealerLoad.Name = "dealerLoad";
            this.dealerLoad.Size = new System.Drawing.Size(75, 23);
            this.dealerLoad.TabIndex = 31;
            this.dealerLoad.Text = "Load";
            this.dealerLoad.UseVisualStyleBackColor = true;
            this.dealerLoad.Click += new System.EventHandler(this.dealerLoad_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 386);
            this.Controls.Add(this.dealerLoad);
            this.Controls.Add(this.customerLoad);
            this.Controls.Add(this.CarLoad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namelast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dealerBox);
            this.Controls.Add(this.custBox);
            this.Controls.Add(this.capacityBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.modelBox);
            this.Controls.Add(this.dealerTownBox);
            this.Controls.Add(this.dealerNameBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.name1Box);
            this.Controls.Add(this.makeBox);
            this.Controls.Add(this.carUpdate);
            this.Controls.Add(this.customerUpdate);
            this.Controls.Add(this.dealerUpdate);
            this.Controls.Add(this.carDealerBox);
            this.Controls.Add(this.customerBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.carBox);
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox carBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox customerBox;
        private System.Windows.Forms.ComboBox carDealerBox;
        private System.Windows.Forms.Button dealerUpdate;
        private System.Windows.Forms.Button customerUpdate;
        private System.Windows.Forms.Button carUpdate;
        private System.Windows.Forms.TextBox makeBox;
        private System.Windows.Forms.TextBox name1Box;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox dealerNameBox;
        private System.Windows.Forms.TextBox dealerTownBox;
        private System.Windows.Forms.TextBox modelBox;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.TextBox capacityBox;
        private System.Windows.Forms.TextBox custBox;
        private System.Windows.Forms.TextBox dealerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label namelast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CarLoad;
        private System.Windows.Forms.Button customerLoad;
        private System.Windows.Forms.Button dealerLoad;
    }
}