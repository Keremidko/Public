using System.Drawing;
using System.Windows.Forms;

namespace DS_Project
{
    partial class PoligonDrawControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.pointGroup = new System.Windows.Forms.GroupBox();
            this.yInput = new System.Windows.Forms.NumericUpDown();
            this.polygonPaintArea = new System.Windows.Forms.Panel();
            this.xInput = new System.Windows.Forms.NumericUpDown();
            this.existingPointsGroup = new System.Windows.Forms.GroupBox();
            this.deletePoint = new System.Windows.Forms.Button();
            this.existingPoints = new System.Windows.Forms.ListBox();
            this.drawPolybutton = new System.Windows.Forms.Button();
            this.polyGroup = new System.Windows.Forms.GroupBox();
            this.brushGroup = new System.Windows.Forms.GroupBox();
            this.thicknessInput = new System.Windows.Forms.NumericUpDown();
            this.brushReset = new System.Windows.Forms.Button();
            this.colorInput = new System.Windows.Forms.Button();
            this.labelColor = new System.Windows.Forms.Label();
            this.thicknessLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.cleanButton = new System.Windows.Forms.Button();
            this.pointGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xInput)).BeginInit();
            this.existingPointsGroup.SuspendLayout();
            this.polyGroup.SuspendLayout();
            this.brushGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessInput)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(6, 27);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "X";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(6, 55);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 13);
            this.yLabel.TabIndex = 1;
            this.yLabel.Text = "Y";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(9, 83);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(93, 25);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добави";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // pointGroup
            // 
            this.pointGroup.Controls.Add(this.yInput);
            this.pointGroup.Controls.Add(this.xInput);
            this.pointGroup.Controls.Add(this.addButton);
            this.pointGroup.Controls.Add(this.xLabel);
            this.pointGroup.Controls.Add(this.yLabel);
            this.pointGroup.Location = new System.Drawing.Point(15, 9);
            this.pointGroup.Name = "pointGroup";
            this.pointGroup.Size = new System.Drawing.Size(108, 114);
            this.pointGroup.TabIndex = 6;
            this.pointGroup.TabStop = false;
            this.pointGroup.Text = "Точка";
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(32, 50);
            this.yInput.Maximum = this.polygonPaintArea.Height;
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(62, 20);
            this.yInput.TabIndex = 5;
            // 
            // polygonPaintArea
            // 
            this.polygonPaintArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.polygonPaintArea.Location = new System.Drawing.Point(9, 19);
            this.polygonPaintArea.Name = "polygonPaintArea";
            this.polygonPaintArea.Size = new System.Drawing.Size(408, 230);
            this.polygonPaintArea.TabIndex = 0;
            this.polygonPaintArea.Click += new System.EventHandler(this.polygonPaintArea_Click);
            this.polygonPaintArea.Paint += new System.Windows.Forms.PaintEventHandler(this.polygonPaintArea_Paint);
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(32, 25);
            this.xInput.Maximum = this.polygonPaintArea.Width;
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(62, 20);
            this.xInput.TabIndex = 0;
            // 
            // existingPointsGroup
            // 
            this.existingPointsGroup.Controls.Add(this.deletePoint);
            this.existingPointsGroup.Controls.Add(this.existingPoints);
            this.existingPointsGroup.Location = new System.Drawing.Point(129, 9);
            this.existingPointsGroup.Name = "existingPointsGroup";
            this.existingPointsGroup.Size = new System.Drawing.Size(184, 114);
            this.existingPointsGroup.TabIndex = 7;
            this.existingPointsGroup.TabStop = false;
            this.existingPointsGroup.Text = "Добавени точки";
            // 
            // deletePoint
            // 
            this.deletePoint.Location = new System.Drawing.Point(6, 85);
            this.deletePoint.Name = "deletePoint";
            this.deletePoint.Size = new System.Drawing.Size(172, 23);
            this.deletePoint.TabIndex = 1;
            this.deletePoint.Text = "Изтрий точка";
            this.deletePoint.UseVisualStyleBackColor = true;
            this.deletePoint.Click += new System.EventHandler(this.deletePoint_Click);
            // 
            // existingPoints
            // 
            this.existingPoints.FormattingEnabled = true;
            this.existingPoints.Location = new System.Drawing.Point(6, 23);
            this.existingPoints.Name = "existingPoints";
            this.existingPoints.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.existingPoints.Size = new System.Drawing.Size(172, 56);
            this.existingPoints.TabIndex = 0;
            // 
            // drawPolybutton
            // 
            this.drawPolybutton.Location = new System.Drawing.Point(15, 129);
            this.drawPolybutton.Name = "drawPolybutton";
            this.drawPolybutton.Size = new System.Drawing.Size(219, 23);
            this.drawPolybutton.TabIndex = 8;
            this.drawPolybutton.Text = "Изчертай";
            this.drawPolybutton.UseVisualStyleBackColor = true;
            this.drawPolybutton.Click += new System.EventHandler(this.drawPolybutton_Click);
            // 
            // polyGroup
            // 
            this.polyGroup.Controls.Add(this.polygonPaintArea);
            this.polyGroup.Location = new System.Drawing.Point(15, 158);
            this.polyGroup.Name = "polyGroup";
            this.polyGroup.Size = new System.Drawing.Size(426, 255);
            this.polyGroup.TabIndex = 9;
            this.polyGroup.TabStop = false;
            this.polyGroup.Text = "Полигон";
            // 
            // brushGroup
            // 
            this.brushGroup.Controls.Add(this.thicknessInput);
            this.brushGroup.Controls.Add(this.brushReset);
            this.brushGroup.Controls.Add(this.colorInput);
            this.brushGroup.Controls.Add(this.labelColor);
            this.brushGroup.Controls.Add(this.thicknessLabel);
            this.brushGroup.Location = new System.Drawing.Point(319, 9);
            this.brushGroup.Name = "brushGroup";
            this.brushGroup.Size = new System.Drawing.Size(122, 114);
            this.brushGroup.TabIndex = 12;
            this.brushGroup.TabStop = false;
            this.brushGroup.Text = "Четка";
            // 
            // thicknessInput
            // 
            this.thicknessInput.Location = new System.Drawing.Point(76, 27);
            this.thicknessInput.Name = "thicknessInput";
            this.thicknessInput.Size = new System.Drawing.Size(35, 20);
            this.thicknessInput.TabIndex = 5;
            this.thicknessInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // brushReset
            // 
            this.brushReset.Location = new System.Drawing.Point(9, 83);
            this.brushReset.Name = "brushReset";
            this.brushReset.Size = new System.Drawing.Size(102, 23);
            this.brushReset.TabIndex = 4;
            this.brushReset.Text = "Преустанови";
            this.brushReset.UseVisualStyleBackColor = true;
            this.brushReset.Click += new System.EventHandler(this.brushReset_Click);
            // 
            // colorInput
            // 
            this.colorInput.BackColor = System.Drawing.Color.Red;
            this.colorInput.Location = new System.Drawing.Point(76, 52);
            this.colorInput.Name = "colorInput";
            this.colorInput.Size = new System.Drawing.Size(37, 23);
            this.colorInput.TabIndex = 3;
            this.colorInput.UseVisualStyleBackColor = false;
            this.colorInput.Click += new System.EventHandler(this.colorInput_Click);
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(6, 57);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(32, 13);
            this.labelColor.TabIndex = 2;
            this.labelColor.Text = "Цвят";
            // 
            // thicknessLabel
            // 
            this.thicknessLabel.AutoSize = true;
            this.thicknessLabel.Location = new System.Drawing.Point(6, 29);
            this.thicknessLabel.Name = "thicknessLabel";
            this.thicknessLabel.Size = new System.Drawing.Size(58, 13);
            this.thicknessLabel.TabIndex = 0;
            this.thicknessLabel.Text = "Дебелина";
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(240, 129);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(201, 23);
            this.cleanButton.TabIndex = 13;
            this.cleanButton.Text = "Изтрий";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // PoligonDrawControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.brushGroup);
            this.Controls.Add(this.polyGroup);
            this.Controls.Add(this.drawPolybutton);
            this.Controls.Add(this.existingPointsGroup);
            this.Controls.Add(this.pointGroup);
            this.Name = "PoligonDrawControl";
            this.Size = new System.Drawing.Size(454, 422);
            this.pointGroup.ResumeLayout(false);
            this.pointGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xInput)).EndInit();
            this.existingPointsGroup.ResumeLayout(false);
            this.polyGroup.ResumeLayout(false);
            this.brushGroup.ResumeLayout(false);
            this.brushGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox pointGroup;
        private System.Windows.Forms.GroupBox existingPointsGroup;
        private System.Windows.Forms.ListBox existingPoints;
        private System.Windows.Forms.Button drawPolybutton;
        private System.Windows.Forms.Button deletePoint;
        private System.Windows.Forms.GroupBox polyGroup;
        private System.Windows.Forms.GroupBox brushGroup;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label thicknessLabel;
        private System.Windows.Forms.Button colorInput;
        private System.Windows.Forms.Button brushReset;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown thicknessInput;
        private System.Windows.Forms.NumericUpDown xInput;
        private System.Windows.Forms.NumericUpDown yInput;
        private System.Windows.Forms.Panel polygonPaintArea;
        private Button cleanButton;
    }
}
