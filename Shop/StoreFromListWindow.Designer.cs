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
            this.addList.Location = new System.Drawing.Point(57, 278);
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
            this.ChooseStore.Location = new System.Drawing.Point(57, 327);
            this.ChooseStore.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseStore.Name = "ChooseStore";
            this.ChooseStore.Size = new System.Drawing.Size(187, 49);
            this.ChooseStore.TabIndex = 3;
            this.ChooseStore.Text = "Choose a store";
            this.ChooseStore.UseVisualStyleBackColor = true;
            this.ChooseStore.Click += new System.EventHandler(this.ChooseStore_Click);
            // 
            // storeName
            // 
            this.storeName.Location = new System.Drawing.Point(57, 401);
            this.storeName.Margin = new System.Windows.Forms.Padding(4);
            this.storeName.Name = "storeName";
            this.storeName.Size = new System.Drawing.Size(185, 22);
            this.storeName.TabIndex = 4;
            // 
            // EstimatePrice
            // 
            this.EstimatePrice.Location = new System.Drawing.Point(283, 327);
            this.EstimatePrice.Margin = new System.Windows.Forms.Padding(4);
            this.EstimatePrice.Name = "EstimatePrice";
            this.EstimatePrice.Size = new System.Drawing.Size(143, 49);
            this.EstimatePrice.TabIndex = 5;
            this.EstimatePrice.Text = "Estimate price";
            this.EstimatePrice.UseVisualStyleBackColor = true;
            this.EstimatePrice.Click += new System.EventHandler(this.EstimatePrice_Click);
            // 
            // totalPrice
            // 
            this.totalPrice.Location = new System.Drawing.Point(283, 400);
            this.totalPrice.Margin = new System.Windows.Forms.Padding(4);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(141, 22);
            this.totalPrice.TabIndex = 6;
            // 
            // StoreFromListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(471, 574);
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
    }
}