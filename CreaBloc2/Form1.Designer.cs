﻿using System;
using System.Windows.Forms;

namespace CreaBloc2
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.DataBloc = new System.Windows.Forms.DataGridView();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.référence = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Reprère = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.composantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.françaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blocUnitaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blocFinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composantselemBlocBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbGroupe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCoffret = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.composantsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dBBlocsDataSet2 = new CreaBloc2.DBBlocsDataSet();
            this.dBBlocsDataSet1 = new CreaBloc2.DBBlocsDataSet();
            this.elemBlocTableAdapter1 = new CreaBloc2.DBBlocsDataSetTableAdapters.elemBlocTableAdapter();
            this.composantsTableAdapter1 = new CreaBloc2.DBBlocsDataSetTableAdapters.ComposantsTableAdapter();
            this.elemBlocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataBloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.composantsBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.composantselemBlocBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.composantsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBlocsDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBlocsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemBlocBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DataBloc
            // 
            this.DataBloc.AllowUserToAddRows = false;
            this.DataBloc.AllowUserToDeleteRows = false;
            this.DataBloc.AllowUserToResizeColumns = false;
            this.DataBloc.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DataBloc, "DataBloc");
            this.DataBloc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataBloc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataBloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBloc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.position,
            this.référence,
            this.Reprère});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataBloc.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataBloc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataBloc.GridColor = System.Drawing.SystemColors.Control;
            this.DataBloc.Name = "DataBloc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataBloc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataBloc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataBloc.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataBloc_RowsAdded);
            this.DataBloc.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataBloc_RowsRemoved);
            // 
            // position
            // 
            resources.ApplyResources(this.position, "position");
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // référence
            // 
            this.référence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.référence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.référence, "référence");
            this.référence.Name = "référence";
            // 
            // Reprère
            // 
            resources.ApplyResources(this.Reprère, "Reprère");
            this.Reprère.MaxInputLength = 4;
            this.Reprère.Name = "Reprère";
            this.Reprère.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reprère.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.cheminToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.françaisToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // françaisToolStripMenuItem
            // 
            this.françaisToolStripMenuItem.Name = "françaisToolStripMenuItem";
            resources.ApplyResources(this.françaisToolStripMenuItem, "françaisToolStripMenuItem");
            this.françaisToolStripMenuItem.Click += new System.EventHandler(this.françaisToolStripMenuItem_Click);
            // 
            // cheminToolStripMenuItem
            // 
            this.cheminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blocUnitaireToolStripMenuItem,
            this.blocFinalToolStripMenuItem});
            this.cheminToolStripMenuItem.Name = "cheminToolStripMenuItem";
            resources.ApplyResources(this.cheminToolStripMenuItem, "cheminToolStripMenuItem");
            // 
            // blocUnitaireToolStripMenuItem
            // 
            this.blocUnitaireToolStripMenuItem.Name = "blocUnitaireToolStripMenuItem";
            resources.ApplyResources(this.blocUnitaireToolStripMenuItem, "blocUnitaireToolStripMenuItem");
            this.blocUnitaireToolStripMenuItem.Click += new System.EventHandler(this.blocUnitaireToolStripMenuItem_Click);
            // 
            // blocFinalToolStripMenuItem
            // 
            this.blocFinalToolStripMenuItem.Name = "blocFinalToolStripMenuItem";
            resources.ApplyResources(this.blocFinalToolStripMenuItem, "blocFinalToolStripMenuItem");
            this.blocFinalToolStripMenuItem.Click += new System.EventHandler(this.blocFinalToolStripMenuItem_Click);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            resources.ApplyResources(this.cbType, "cbType");
            this.cbType.Name = "cbType";
            // 
            // cbGroupe
            // 
            this.cbGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupe.FormattingEnabled = true;
            resources.ApplyResources(this.cbGroupe, "cbGroupe");
            this.cbGroupe.Name = "cbGroupe";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cbCoffret
            // 
            this.cbCoffret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoffret.FormattingEnabled = true;
            resources.ApplyResources(this.cbCoffret, "cbCoffret");
            this.cbCoffret.Name = "cbCoffret";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // composantsBindingSource1
            // 
            this.composantsBindingSource1.DataMember = "Composants";
            this.composantsBindingSource1.DataSource = this.dBBlocsDataSet2;
            // 
            // dBBlocsDataSet2
            // 
            this.dBBlocsDataSet2.DataSetName = "DBBlocsDataSet";
            this.dBBlocsDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dBBlocsDataSet1
            // 
            this.dBBlocsDataSet1.DataSetName = "DBBlocsDataSet";
            this.dBBlocsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // elemBlocTableAdapter1
            // 
            this.elemBlocTableAdapter1.ClearBeforeFill = true;
            // 
            // composantsTableAdapter1
            // 
            this.composantsTableAdapter1.ClearBeforeFill = true;
            // 
            // elemBlocBindingSource
            // 
            this.elemBlocBindingSource.DataMember = "elemBloc";
            this.elemBlocBindingSource.DataSource = this.dBBlocsDataSet1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbCoffret);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbGroupe);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.DataBloc);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataBloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.composantsBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.composantselemBlocBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.composantsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBlocsDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBlocsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemBlocBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView DataBloc;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DBBlocsDataSet dBBlocsDataSet;
        private DBBlocsDataSetTableAdapters.ComposantsTableAdapter composantsTableAdapter;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem françaisToolStripMenuItem;
        private DBBlocsDataSetTableAdapters.elemBlocTableAdapter elemBlocTableAdapter;
        private BindingSource composantselemBlocBindingSource1;
        private BindingSource composantsBindingSource;
        private DBBlocsDataSet dBBlocsDataSet1;
        private DBBlocsDataSetTableAdapters.elemBlocTableAdapter elemBlocTableAdapter1;
        private DBBlocsDataSet dBBlocsDataSet2;
        private BindingSource composantsBindingSource1;
        private DBBlocsDataSetTableAdapters.ComposantsTableAdapter composantsTableAdapter1;
        private BindingSource elemBlocBindingSource;
        private ToolStripMenuItem cheminToolStripMenuItem;
        private ToolStripMenuItem blocUnitaireToolStripMenuItem;
        private ToolStripMenuItem blocFinalToolStripMenuItem;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label2;
        private Label label3;
        private ComboBox cbType;
        private ComboBox cbGroupe;
        private Label label1;
        private Label label4;
        private ComboBox cbCoffret;
        private Label label5;
        private DataGridViewTextBoxColumn position;
        private DataGridViewComboBoxColumn référence;
        private DataGridViewTextBoxColumn Reprère;
    }
}

