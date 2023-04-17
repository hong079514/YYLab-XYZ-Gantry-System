using System;

namespace EX3_BasicMoves
{
    partial class BasicMoves
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
			this.components = new System.ComponentModel.Container();
			this.HomeAxisButton = new System.Windows.Forms.Button();
			this.enableButton = new System.Windows.Forms.Button();
			this.doMoveButton = new System.Windows.Forms.Button();
			this.haltMoveButton = new System.Windows.Forms.Button();
			this.VelocityTextBox = new System.Windows.Forms.TextBox();
			this.AccelTextBox = new System.Windows.Forms.TextBox();
			this.DecelTextBox = new System.Windows.Forms.TextBox();
			this.X_DistanceTextBox = new System.Windows.Forms.TextBox();
			this.posTextBox = new System.Windows.Forms.TextBox();
			this.velocityLabel = new System.Windows.Forms.Label();
			this.AccelerationLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.Y_DistanceTextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.X_StepTextBox = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.Y_StepTextBox = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.y_postextbox = new System.Windows.Forms.TextBox();
			this.Modified_Button = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.Modified_Y_Textbox = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.Modified_X_Textbox = new System.Windows.Forms.TextBox();
			this.Move_Z_Up_Button = new System.Windows.Forms.Button();
			this.Move_Z_down_Button = new System.Windows.Forms.Button();
			this.scan_button = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.x2Pos = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// HomeAxisButton
			// 
			this.HomeAxisButton.Location = new System.Drawing.Point(183, 215);
			this.HomeAxisButton.Margin = new System.Windows.Forms.Padding(2);
			this.HomeAxisButton.Name = "HomeAxisButton";
			this.HomeAxisButton.Size = new System.Drawing.Size(88, 30);
			this.HomeAxisButton.TabIndex = 0;
			this.HomeAxisButton.Text = "Home Axis";
			this.HomeAxisButton.UseVisualStyleBackColor = true;
			this.HomeAxisButton.Click += new System.EventHandler(this.HomeAxisButton_Click);
			// 
			// enableButton
			// 
			this.enableButton.Location = new System.Drawing.Point(11, 11);
			this.enableButton.Margin = new System.Windows.Forms.Padding(2);
			this.enableButton.Name = "enableButton";
			this.enableButton.Size = new System.Drawing.Size(82, 26);
			this.enableButton.TabIndex = 1;
			this.enableButton.Text = "Amp Disable";
			this.enableButton.UseVisualStyleBackColor = true;
			this.enableButton.Click += new System.EventHandler(this.enableButton_Click);
			// 
			// doMoveButton
			// 
			this.doMoveButton.Location = new System.Drawing.Point(189, 385);
			this.doMoveButton.Margin = new System.Windows.Forms.Padding(2);
			this.doMoveButton.Name = "doMoveButton";
			this.doMoveButton.Size = new System.Drawing.Size(82, 26);
			this.doMoveButton.TabIndex = 2;
			this.doMoveButton.Text = "Scan Move";
			this.doMoveButton.UseVisualStyleBackColor = true;
			this.doMoveButton.Click += new System.EventHandler(this.doMoveButton_Click);
			// 
			// haltMoveButton
			// 
			this.haltMoveButton.Location = new System.Drawing.Point(156, 11);
			this.haltMoveButton.Margin = new System.Windows.Forms.Padding(2);
			this.haltMoveButton.Name = "haltMoveButton";
			this.haltMoveButton.Size = new System.Drawing.Size(73, 26);
			this.haltMoveButton.TabIndex = 3;
			this.haltMoveButton.Text = "Halt Move";
			this.haltMoveButton.UseVisualStyleBackColor = true;
			this.haltMoveButton.Click += new System.EventHandler(this.haltMoveButton_Click);
			// 
			// VelocityTextBox
			// 
			this.VelocityTextBox.AccessibleDescription = "";
			this.VelocityTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
			this.VelocityTextBox.Location = new System.Drawing.Point(234, 60);
			this.VelocityTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.VelocityTextBox.Name = "VelocityTextBox";
			this.VelocityTextBox.Size = new System.Drawing.Size(76, 20);
			this.VelocityTextBox.TabIndex = 4;
			this.VelocityTextBox.Text = "4000";
			this.VelocityTextBox.TextChanged += new System.EventHandler(this.VelocityTextBox_TextChanged);
			// 
			// AccelTextBox
			// 
			this.AccelTextBox.Location = new System.Drawing.Point(234, 91);
			this.AccelTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.AccelTextBox.Name = "AccelTextBox";
			this.AccelTextBox.Size = new System.Drawing.Size(76, 20);
			this.AccelTextBox.TabIndex = 5;
			this.AccelTextBox.Text = "4000";
			this.AccelTextBox.TextChanged += new System.EventHandler(this.AccelTextBox_TextChanged);
			// 
			// DecelTextBox
			// 
			this.DecelTextBox.Location = new System.Drawing.Point(234, 125);
			this.DecelTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.DecelTextBox.Name = "DecelTextBox";
			this.DecelTextBox.Size = new System.Drawing.Size(76, 20);
			this.DecelTextBox.TabIndex = 6;
			this.DecelTextBox.Text = "4000";
			// 
			// X_DistanceTextBox
			// 
			this.X_DistanceTextBox.Location = new System.Drawing.Point(195, 415);
			this.X_DistanceTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.X_DistanceTextBox.Name = "X_DistanceTextBox";
			this.X_DistanceTextBox.Size = new System.Drawing.Size(76, 20);
			this.X_DistanceTextBox.TabIndex = 7;
			this.X_DistanceTextBox.Text = "20000";
			this.X_DistanceTextBox.TextChanged += new System.EventHandler(this.DistanceTextBox_TextChanged);
			// 
			// posTextBox
			// 
			this.posTextBox.Location = new System.Drawing.Point(204, 526);
			this.posTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.posTextBox.Name = "posTextBox";
			this.posTextBox.ReadOnly = true;
			this.posTextBox.Size = new System.Drawing.Size(76, 20);
			this.posTextBox.TabIndex = 8;
			this.posTextBox.TextChanged += new System.EventHandler(this.posTextBox_TextChanged);
			// 
			// velocityLabel
			// 
			this.velocityLabel.AutoSize = true;
			this.velocityLabel.Location = new System.Drawing.Point(125, 60);
			this.velocityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.velocityLabel.Name = "velocityLabel";
			this.velocityLabel.Size = new System.Drawing.Size(44, 13);
			this.velocityLabel.TabIndex = 9;
			this.velocityLabel.Text = "Velocity";
			// 
			// AccelerationLabel
			// 
			this.AccelerationLabel.AutoSize = true;
			this.AccelerationLabel.Location = new System.Drawing.Point(125, 95);
			this.AccelerationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.AccelerationLabel.Name = "AccelerationLabel";
			this.AccelerationLabel.Size = new System.Drawing.Size(66, 13);
			this.AccelerationLabel.TabIndex = 10;
			this.AccelerationLabel.Text = "Acceleration";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(125, 129);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Deceleration";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(93, 419);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "X Move Distance";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(95, 559);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "x2_Actual Position";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(314, 64);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "counts/s";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(314, 95);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "counts/s^2";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(314, 129);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "counts/s^2";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(275, 419);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "counts";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(284, 557);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "counts";
			// 
			// Timer1
			// 
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(275, 467);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "counts";
			this.label9.Click += new System.EventHandler(this.label9_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(93, 467);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(89, 13);
			this.label10.TabIndex = 20;
			this.label10.Text = "Y Move Distance";
			this.label10.Click += new System.EventHandler(this.label10_Click);
			// 
			// Y_DistanceTextBox
			// 
			this.Y_DistanceTextBox.Location = new System.Drawing.Point(195, 463);
			this.Y_DistanceTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.Y_DistanceTextBox.Name = "Y_DistanceTextBox";
			this.Y_DistanceTextBox.Size = new System.Drawing.Size(76, 20);
			this.Y_DistanceTextBox.TabIndex = 19;
			this.Y_DistanceTextBox.Text = "20000";
			this.Y_DistanceTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(275, 443);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(39, 13);
			this.label11.TabIndex = 24;
			this.label11.Text = "counts";
			this.label11.Click += new System.EventHandler(this.label11_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(93, 442);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(69, 13);
			this.label12.TabIndex = 23;
			this.label12.Text = "X Move Step";
			this.label12.Click += new System.EventHandler(this.label12_Click);
			// 
			// X_StepTextBox
			// 
			this.X_StepTextBox.Location = new System.Drawing.Point(195, 439);
			this.X_StepTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.X_StepTextBox.Name = "X_StepTextBox";
			this.X_StepTextBox.Size = new System.Drawing.Size(76, 20);
			this.X_StepTextBox.TabIndex = 22;
			this.X_StepTextBox.Text = "5000";
			this.X_StepTextBox.TextChanged += new System.EventHandler(this.X_StepTextBox_TextChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(275, 491);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(39, 13);
			this.label13.TabIndex = 27;
			this.label13.Text = "counts";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(93, 490);
			this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(69, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "Y Move Step";
			this.label14.Click += new System.EventHandler(this.label14_Click);
			// 
			// Y_StepTextBox
			// 
			this.Y_StepTextBox.Location = new System.Drawing.Point(195, 487);
			this.Y_StepTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.Y_StepTextBox.Name = "Y_StepTextBox";
			this.Y_StepTextBox.Size = new System.Drawing.Size(76, 20);
			this.Y_StepTextBox.TabIndex = 25;
			this.Y_StepTextBox.Text = "5000";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(284, 584);
			this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(39, 13);
			this.label15.TabIndex = 30;
			this.label15.Text = "counts";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(93, 584);
			this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 13);
			this.label16.TabIndex = 29;
			this.label16.Text = "y_Actual Position";
			this.label16.Click += new System.EventHandler(this.label16_Click);
			// 
			// y_postextbox
			// 
			this.y_postextbox.Location = new System.Drawing.Point(204, 581);
			this.y_postextbox.Margin = new System.Windows.Forms.Padding(2);
			this.y_postextbox.Name = "y_postextbox";
			this.y_postextbox.ReadOnly = true;
			this.y_postextbox.Size = new System.Drawing.Size(76, 20);
			this.y_postextbox.TabIndex = 28;
			this.y_postextbox.TextChanged += new System.EventHandler(this.y_postextbox_TextChanged);
			// 
			// Modified_Button
			// 
			this.Modified_Button.Location = new System.Drawing.Point(183, 277);
			this.Modified_Button.Margin = new System.Windows.Forms.Padding(2);
			this.Modified_Button.Name = "Modified_Button";
			this.Modified_Button.Size = new System.Drawing.Size(88, 26);
			this.Modified_Button.TabIndex = 31;
			this.Modified_Button.Text = "Modified Move";
			this.Modified_Button.UseVisualStyleBackColor = true;
			this.Modified_Button.Click += new System.EventHandler(this.Modified_Button_Click);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(275, 338);
			this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(39, 13);
			this.label17.TabIndex = 37;
			this.label17.Text = "counts";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(86, 337);
			this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(96, 13);
			this.label18.TabIndex = 36;
			this.label18.Text = "Modified Y position";
			this.label18.Click += new System.EventHandler(this.label18_Click);
			// 
			// Modified_Y_Textbox
			// 
			this.Modified_Y_Textbox.Location = new System.Drawing.Point(195, 334);
			this.Modified_Y_Textbox.Margin = new System.Windows.Forms.Padding(2);
			this.Modified_Y_Textbox.Name = "Modified_Y_Textbox";
			this.Modified_Y_Textbox.Size = new System.Drawing.Size(76, 20);
			this.Modified_Y_Textbox.TabIndex = 35;
			this.Modified_Y_Textbox.Text = "-20000";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(275, 311);
			this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(39, 13);
			this.label19.TabIndex = 34;
			this.label19.Text = "counts";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(86, 310);
			this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(96, 13);
			this.label20.TabIndex = 33;
			this.label20.Text = "Modified X position";
			// 
			// Modified_X_Textbox
			// 
			this.Modified_X_Textbox.Location = new System.Drawing.Point(195, 307);
			this.Modified_X_Textbox.Margin = new System.Windows.Forms.Padding(2);
			this.Modified_X_Textbox.Name = "Modified_X_Textbox";
			this.Modified_X_Textbox.Size = new System.Drawing.Size(76, 20);
			this.Modified_X_Textbox.TabIndex = 32;
			this.Modified_X_Textbox.Text = "-20000";
			this.Modified_X_Textbox.TextChanged += new System.EventHandler(this.Modified_X_Textbox_TextChanged);
			// 
			// Move_Z_Up_Button
			// 
			this.Move_Z_Up_Button.Location = new System.Drawing.Point(128, 166);
			this.Move_Z_Up_Button.Margin = new System.Windows.Forms.Padding(2);
			this.Move_Z_Up_Button.Name = "Move_Z_Up_Button";
			this.Move_Z_Up_Button.Size = new System.Drawing.Size(82, 26);
			this.Move_Z_Up_Button.TabIndex = 38;
			this.Move_Z_Up_Button.Text = "Move Z Up";
			this.Move_Z_Up_Button.UseVisualStyleBackColor = true;
			this.Move_Z_Up_Button.Click += new System.EventHandler(this.Move_Z_Up_Button_Click);
			// 
			// Move_Z_down_Button
			// 
			this.Move_Z_down_Button.Location = new System.Drawing.Point(241, 167);
			this.Move_Z_down_Button.Margin = new System.Windows.Forms.Padding(2);
			this.Move_Z_down_Button.Name = "Move_Z_down_Button";
			this.Move_Z_down_Button.Size = new System.Drawing.Size(82, 26);
			this.Move_Z_down_Button.TabIndex = 39;
			this.Move_Z_down_Button.Text = "Move Z down";
			this.Move_Z_down_Button.UseVisualStyleBackColor = true;
			this.Move_Z_down_Button.Click += new System.EventHandler(this.Move_Z_down_Button_Click);
			// 
			// scan_button
			// 
			this.scan_button.Location = new System.Drawing.Point(278, 11);
			this.scan_button.Margin = new System.Windows.Forms.Padding(2);
			this.scan_button.Name = "scan_button";
			this.scan_button.Size = new System.Drawing.Size(73, 26);
			this.scan_button.TabIndex = 40;
			this.scan_button.Text = "Scan";
			this.scan_button.UseVisualStyleBackColor = true;
			this.scan_button.Click += new System.EventHandler(this.button1_Click);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.Location = new System.Drawing.Point(27, 57);
			this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(75, 22);
			this.label21.TabIndex = 41;
			this.label21.Text = "Settings";
			this.label21.Click += new System.EventHandler(this.label21_Click);
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.Location = new System.Drawing.Point(27, 167);
			this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(73, 22);
			this.label22.TabIndex = 42;
			this.label22.Text = "Move Z";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.Location = new System.Drawing.Point(27, 223);
			this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(129, 22);
			this.label23.TabIndex = 43;
			this.label23.Text = "Home Position";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.Location = new System.Drawing.Point(27, 277);
			this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(122, 22);
			this.label24.TabIndex = 44;
			this.label24.Text = "Start Position";
			this.label24.Click += new System.EventHandler(this.label24_Click);
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.Location = new System.Drawing.Point(27, 385);
			this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(101, 22);
			this.label25.TabIndex = 45;
			this.label25.Text = "Scan Move";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label26.Location = new System.Drawing.Point(27, 532);
			this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(61, 22);
			this.label26.TabIndex = 46;
			this.label26.Text = "Status";
			this.label26.Click += new System.EventHandler(this.label26_Click);
			// 
			// x2Pos
			// 
			this.x2Pos.Location = new System.Drawing.Point(204, 550);
			this.x2Pos.Margin = new System.Windows.Forms.Padding(2);
			this.x2Pos.Name = "x2Pos";
			this.x2Pos.ReadOnly = true;
			this.x2Pos.Size = new System.Drawing.Size(76, 20);
			this.x2Pos.TabIndex = 8;
			this.x2Pos.TextChanged += new System.EventHandler(this.posTextBox_TextChanged);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(95, 535);
			this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(94, 13);
			this.label27.TabIndex = 13;
			this.label27.Text = "x1_Actual Position";
			this.label27.Click += new System.EventHandler(this.label3_Click);
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(284, 533);
			this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(39, 13);
			this.label28.TabIndex = 18;
			this.label28.Text = "counts";
			// 
			// BasicMoves
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(468, 612);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.scan_button);
			this.Controls.Add(this.Move_Z_down_Button);
			this.Controls.Add(this.Move_Z_Up_Button);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.Modified_Y_Textbox);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.Modified_X_Textbox);
			this.Controls.Add(this.Modified_Button);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.y_postextbox);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.Y_StepTextBox);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.X_StepTextBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.Y_DistanceTextBox);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.AccelerationLabel);
			this.Controls.Add(this.velocityLabel);
			this.Controls.Add(this.x2Pos);
			this.Controls.Add(this.posTextBox);
			this.Controls.Add(this.X_DistanceTextBox);
			this.Controls.Add(this.DecelTextBox);
			this.Controls.Add(this.AccelTextBox);
			this.Controls.Add(this.VelocityTextBox);
			this.Controls.Add(this.haltMoveButton);
			this.Controls.Add(this.doMoveButton);
			this.Controls.Add(this.enableButton);
			this.Controls.Add(this.HomeAxisButton);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "BasicMoves";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasicMoves_FormClosing);
			this.Load += new System.EventHandler(this.BasicMoves_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		private void label3_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion

		private System.Windows.Forms.Button HomeAxisButton;
        private System.Windows.Forms.Button enableButton;
        private System.Windows.Forms.Button doMoveButton;
        private System.Windows.Forms.Button haltMoveButton;
        private System.Windows.Forms.TextBox VelocityTextBox;
        private System.Windows.Forms.TextBox AccelTextBox;
        private System.Windows.Forms.TextBox DecelTextBox;
        private System.Windows.Forms.TextBox X_DistanceTextBox;
        private System.Windows.Forms.TextBox posTextBox;
        private System.Windows.Forms.Label velocityLabel;
        private System.Windows.Forms.Label AccelerationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Y_DistanceTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox X_StepTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Y_StepTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox y_postextbox;
        private System.Windows.Forms.Button Modified_Button;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox Modified_Y_Textbox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox Modified_X_Textbox;
        private System.Windows.Forms.Button Move_Z_Up_Button;
        private System.Windows.Forms.Button Move_Z_down_Button;
        private System.Windows.Forms.Button scan_button;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox x2Pos;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
	}
}

