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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.DataBloc = new System.Windows.Forms.DataGridView();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Référence = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.composantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBBlocsDataSet = new CreaBloc2.DBBlocsDataSet();
            this.Repère = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.composantsTableAdapter = new CreaBloc2.DBBlocsDataSetTableAdapters.ComposantsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataBloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.composantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBlocsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(251, 28);
            this.textBox1.MaxLength = 11;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bloc référence :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Insérer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Supprimer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(202, 402);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 26);
            this.button3.TabIndex = 4;
            this.button3.Text = "Créer xrb";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(457, 402);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 26);
            this.button4.TabIndex = 5;
            this.button4.Text = "Annuler";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(545, 402);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 26);
            this.button5.TabIndex = 6;
            this.button5.Text = "OK";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DataBloc
            // 
            this.DataBloc.AllowUserToResizeColumns = false;
            this.DataBloc.AllowUserToResizeRows = false;
            this.DataBloc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataBloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBloc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.position,
            this.Référence,
            this.Repère});
            this.DataBloc.GridColor = System.Drawing.SystemColors.Control;
            this.DataBloc.Location = new System.Drawing.Point(26, 55);
            this.DataBloc.Name = "DataBloc";
            this.DataBloc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataBloc.Size = new System.Drawing.Size(600, 341);
            this.DataBloc.TabIndex = 7;
            this.DataBloc.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataBloc_RowsAdded);
            // 
            // position
            // 
            this.position.HeaderText = "Position";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.position.Width = 69;
            // 
            // Référence
            // 
            this.Référence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Référence.DataSource = this.composantsBindingSource;
            this.Référence.DisplayMember = "Réferences";
            this.Référence.HeaderText = "Référence";
            this.Référence.Name = "Référence";
            this.Référence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Référence.ValueMember = "Clé";
            // 
            // composantsBindingSource
            // 
            this.composantsBindingSource.DataMember = "Composants";
            this.composantsBindingSource.DataSource = this.dBBlocsDataSet;
            // 
            // dBBlocsDataSet
            // 
            this.dBBlocsDataSet.DataSetName = "DBBlocsDataSet";
            this.dBBlocsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Repère
            // 
            this.Repère.HeaderText = "Repère";
            this.Repère.Name = "Repère";
            this.Repère.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Repère.Width = 67;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(26, 28);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 21);
            this.button6.TabIndex = 8;
            this.button6.Text = "Ouvrir";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(551, 26);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Connexion";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // composantsTableAdapter
            // 
            this.composantsTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 461);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.DataBloc);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "CreaBloc";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataBloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.composantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBlocsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView DataBloc;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button7;
        private DBBlocsDataSet dBBlocsDataSet;
        private System.Windows.Forms.BindingSource composantsBindingSource;
        private DBBlocsDataSetTableAdapters.ComposantsTableAdapter composantsTableAdapter;
        private DataGridViewTextBoxColumn position;
        private DataGridViewComboBoxColumn Référence;
        private DataGridViewTextBoxColumn Repère;
    }
}

