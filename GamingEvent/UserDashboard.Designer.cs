namespace GamingEvent
{
    partial class UserDashboard
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
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.bookBtn = new System.Windows.Forms.Button();
            this.buttonBookings = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(325, 66);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.Size = new System.Drawing.Size(512, 278);
            this.dataGridViewEvents.TabIndex = 0;
            // 
            // bookBtn
            // 
            this.bookBtn.BackColor = System.Drawing.Color.White;
            this.bookBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.bookBtn.FlatAppearance.BorderSize = 2;
            this.bookBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookBtn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bookBtn.Location = new System.Drawing.Point(44, 66);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(206, 57);
            this.bookBtn.TabIndex = 2;
            this.bookBtn.Text = "Book Event";
            this.bookBtn.UseVisualStyleBackColor = false;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // buttonBookings
            // 
            this.buttonBookings.BackColor = System.Drawing.Color.White;
            this.buttonBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBookings.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.buttonBookings.FlatAppearance.BorderSize = 2;
            this.buttonBookings.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBookings.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonBookings.Location = new System.Drawing.Point(44, 171);
            this.buttonBookings.Name = "buttonBookings";
            this.buttonBookings.Size = new System.Drawing.Size(206, 57);
            this.buttonBookings.TabIndex = 3;
            this.buttonBookings.Text = "My Bookings";
            this.buttonBookings.UseVisualStyleBackColor = false;
            this.buttonBookings.Click += new System.EventHandler(this.buttonBookings_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.BackColor = System.Drawing.Color.White;
            this.LogOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogOutBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.LogOutBtn.FlatAppearance.BorderSize = 2;
            this.LogOutBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutBtn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LogOutBtn.Location = new System.Drawing.Point(44, 287);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(206, 57);
            this.LogOutBtn.TabIndex = 4;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = false;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Red;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(790, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(47, 36);
            this.closeBtn.TabIndex = 8;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GamingEvent.Properties.Resources.user1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(849, 494);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.buttonBookings);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.dataGridViewEvents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDashboard";
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.Button buttonBookings;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}