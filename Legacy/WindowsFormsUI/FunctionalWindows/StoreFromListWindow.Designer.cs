namespace Shop
{
    partial class StoreFromListWindow
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
            this.ProductsTextBox = new System.Windows.Forms.RichTextBox();
            this.addList = new System.Windows.Forms.TextBox();
            this.AddToList = new System.Windows.Forms.Button();
            this.ChooseStore = new System.Windows.Forms.Button();
            this.storeName = new System.Windows.Forms.TextBox();
            this.EstimatePrice = new System.Windows.Forms.Button();
            this.totalPrice = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RadiusLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CartLabel = new System.Windows.Forms.Label();
            this.MapLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductsTextBox
            // 
            this.ProductsTextBox.Location = new System.Drawing.Point(57, 31);
            this.ProductsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProductsTextBox.Name = "ProductsTextBox";
            this.ProductsTextBox.Size = new System.Drawing.Size(367, 218);
            this.ProductsTextBox.TabIndex = 0;
            this.ProductsTextBox.Text = "";
            // 
            // addList
            // 
            this.addList.Location = new System.Drawing.Point(59, 281);
            this.addList.Margin = new System.Windows.Forms.Padding(4);
            this.addList.Name = "addList";
            this.addList.Size = new System.Drawing.Size(185, 22);
            this.addList.TabIndex = 1;
            // 
            // AddToList
            // 
            this.AddToList.Location = new System.Drawing.Point(283, 278);
            this.AddToList.Margin = new System.Windows.Forms.Padding(4);
            this.AddToList.Name = "AddToList";
            this.AddToList.Size = new System.Drawing.Size(143, 28);
            this.AddToList.TabIndex = 2;
            this.AddToList.Text = "Add to list";
            this.AddToList.UseVisualStyleBackColor = true;
            this.AddToList.Click += new System.EventHandler(this.AddToList_Click);
            // 
            // ChooseStore
            // 
            this.ChooseStore.Location = new System.Drawing.Point(57, 325);
            this.ChooseStore.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseStore.Name = "ChooseStore";
            this.ChooseStore.Size = new System.Drawing.Size(146, 40);
            this.ChooseStore.TabIndex = 3;
            this.ChooseStore.Text = "Choose a store";
            this.ChooseStore.UseVisualStyleBackColor = true;
            this.ChooseStore.Click += new System.EventHandler(this.ChooseStore_Click);
            // 
            // storeName
            // 
            this.storeName.Location = new System.Drawing.Point(57, 373);
            this.storeName.Margin = new System.Windows.Forms.Padding(4);
            this.storeName.Name = "storeName";
            this.storeName.Size = new System.Drawing.Size(146, 22);
            this.storeName.TabIndex = 4;
            // 
            // EstimatePrice
            // 
            this.EstimatePrice.Location = new System.Drawing.Point(281, 325);
            this.EstimatePrice.Margin = new System.Windows.Forms.Padding(4);
            this.EstimatePrice.Name = "EstimatePrice";
            this.EstimatePrice.Size = new System.Drawing.Size(143, 40);
            this.EstimatePrice.TabIndex = 5;
            this.EstimatePrice.Text = "Estimate price";
            this.EstimatePrice.UseVisualStyleBackColor = true;
            this.EstimatePrice.Click += new System.EventHandler(this.EstimatePrice_Click);
            // 
            // totalPrice
            // 
            this.totalPrice.Location = new System.Drawing.Point(283, 373);
            this.totalPrice.Margin = new System.Windows.Forms.Padding(4);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(141, 22);
            this.totalPrice.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gmap);
            this.panel1.Location = new System.Drawing.Point(477, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 412);
            this.panel1.TabIndex = 7;
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(3, 3);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
           // this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(473, 409);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 12D;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1019, 25);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(832, 474);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 9;
            // 
            // RadiusLabel
            // 
            this.RadiusLabel.AutoSize = true;
            this.RadiusLabel.Location = new System.Drawing.Point(569, 477);
            this.RadiusLabel.Name = "RadiusLabel";
            this.RadiusLabel.Size = new System.Drawing.Size(257, 17);
            this.RadiusLabel.TabIndex = 10;
            this.RadiusLabel.Text = "Select Preferred Shop Radius: (meters)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(832, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Update Map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CartLabel
            // 
            this.CartLabel.AutoSize = true;
            this.CartLabel.Location = new System.Drawing.Point(54, 9);
            this.CartLabel.Name = "CartLabel";
            this.CartLabel.Size = new System.Drawing.Size(136, 17);
            this.CartLabel.TabIndex = 12;
            this.CartLabel.Text = "Your Shopping Cart:";
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(474, 9);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(110, 17);
            this.MapLabel.TabIndex = 13;
            this.MapLabel.Text = "Shop Locations:";
            // 
            // StoreFromListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1019, 574);
            this.Controls.Add(this.MapLabel);
            this.Controls.Add(this.CartLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RadiusLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.EstimatePrice);
            this.Controls.Add(this.storeName);
            this.Controls.Add(this.ChooseStore);
            this.Controls.Add(this.AddToList);
            this.Controls.Add(this.addList);
            this.Controls.Add(this.ProductsTextBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StoreFromListWindow";
            this.Text = "StoreFromListWindow";
            this.Load += new System.EventHandler(this.StoreFromListWindow_Load);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ProductsTextBox;
        private System.Windows.Forms.TextBox addList;
        private System.Windows.Forms.Button AddToList;
        private System.Windows.Forms.Button ChooseStore;
        private System.Windows.Forms.TextBox storeName;
        private System.Windows.Forms.Button EstimatePrice;
        private System.Windows.Forms.TextBox totalPrice;
        private System.Windows.Forms.Panel panel1;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label RadiusLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CartLabel;
        private System.Windows.Forms.Label MapLabel;
    }
}