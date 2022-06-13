﻿namespace Carpiler.WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tb_SourceCode = new System.Windows.Forms.TextBox();
            this.Lv_Errors = new System.Windows.Forms.ListView();
            this.Bt_Source = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Bt_Ast = new System.Windows.Forms.Button();
            this.Tb_Ast = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tb_SourceCode
            // 
            this.Tb_SourceCode.Location = new System.Drawing.Point(10, 10);
            this.Tb_SourceCode.Multiline = true;
            this.Tb_SourceCode.Name = "Tb_SourceCode";
            this.Tb_SourceCode.Size = new System.Drawing.Size(892, 648);
            this.Tb_SourceCode.TabIndex = 0;
            this.Tb_SourceCode.TextChanged += new System.EventHandler(this.Tb_SourceCode_TextChanged);
            // 
            // Lv_Errors
            // 
            this.Lv_Errors.Location = new System.Drawing.Point(3, 677);
            this.Lv_Errors.Name = "Lv_Errors";
            this.Lv_Errors.Size = new System.Drawing.Size(1000, 120);
            this.Lv_Errors.TabIndex = 1;
            this.Lv_Errors.UseCompatibleStateImageBehavior = false;
            // 
            // Bt_Source
            // 
            this.Bt_Source.Location = new System.Drawing.Point(908, 10);
            this.Bt_Source.Name = "Bt_Source";
            this.Bt_Source.Size = new System.Drawing.Size(87, 29);
            this.Bt_Source.TabIndex = 2;
            this.Bt_Source.Text = "Source";
            this.Bt_Source.UseVisualStyleBackColor = true;
            this.Bt_Source.Click += new System.EventHandler(this.Bt_Source_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Tb_Ast);
            this.panel1.Controls.Add(this.Bt_Ast);
            this.panel1.Controls.Add(this.Tb_SourceCode);
            this.panel1.Controls.Add(this.Lv_Errors);
            this.panel1.Controls.Add(this.Bt_Source);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 808);
            this.panel1.TabIndex = 3;
            // 
            // Bt_Ast
            // 
            this.Bt_Ast.Location = new System.Drawing.Point(908, 45);
            this.Bt_Ast.Name = "Bt_Ast";
            this.Bt_Ast.Size = new System.Drawing.Size(87, 29);
            this.Bt_Ast.TabIndex = 3;
            this.Bt_Ast.Text = "AST";
            this.Bt_Ast.UseVisualStyleBackColor = true;
            this.Bt_Ast.Click += new System.EventHandler(this.Bt_Ast_Click);
            // 
            // Tb_Ast
            // 
            this.Tb_Ast.Location = new System.Drawing.Point(10, 11);
            this.Tb_Ast.Multiline = true;
            this.Tb_Ast.Name = "Tb_Ast";
            this.Tb_Ast.ReadOnly = true;
            this.Tb_Ast.Size = new System.Drawing.Size(892, 648);
            this.Tb_Ast.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 811);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox Tb_SourceCode;
        private ListView Lv_Errors;
        private Button Bt_Source;
        private Panel panel1;
        private Button Bt_Ast;
        private TextBox Tb_Ast;
    }
}