namespace GamingEvent
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.dataGridViewParticipants = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.manageEvents = new System.Windows.Forms.Button();
            this.manageUsers = new System.Windows.Forms.Button();
            this.manageBookings = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(420, 77);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.Size = new System.Drawing.Size(342, 164);
            this.dataGridViewEvents.TabIndex = 0;
            // 
            // dataGridViewParticipants
            // 
            this.dataGridViewParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParticipants.Location = new System.Drawing.Point(420, 262);
            this.dataGridViewParticipants.Name = "dataGridViewParticipants";
            this.dataGridViewParticipants.Size = new System.Drawing.Size(342, 164);
            this.dataGridViewParticipants.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Admin Dashboard";
            // 
            // manageEvents
            // 
            this.manageEvents.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.manageEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageEvents.FlatAppearance.BorderSize = 0;
            this.manageEvents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.manageEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageEvents.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageEvents.ForeColor = System.Drawing.Color.White;
            this.manageEvents.Location = new System.Drawing.Point(55, 77);
            this.manageEvents.Name = "manageEvents";
            this.manageEvents.Size = new System.Drawing.Size(199, 47);
            this.manageEvents.TabIndex = 3;
            this.manageEvents.Text = "Manage Events";
            this.manageEvents.UseVisualStyleBackColor = false;
            this.manageEvents.Click += new System.EventHandler(this.manageEvents_Click);
            // 
            // manageUsers
            // 
            this.manageUsers.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.manageUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageUsers.FlatAppearance.BorderSize = 0;
            this.manageUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.manageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageUsers.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageUsers.ForeColor = System.Drawing.Color.White;
            this.manageUsers.Location = new System.Drawing.Point(55, 154);
            this.manageUsers.Name = "manageUsers";
            this.manageUsers.Size = new System.Drawing.Size(199, 47);
            this.manageUsers.TabIndex = 4;
            this.manageUsers.Text = "Manage Users";
            this.manageUsers.UseVisualStyleBackColor = false;
            this.manageUsers.Click += new System.EventHandler(this.manageUsers_Click);
            // 
            // manageBookings
            // 
            this.manageBookings.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.manageBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageBookings.FlatAppearance.BorderSize = 0;
            this.manageBookings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.manageBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageBookings.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageBookings.ForeColor = System.Drawing.Color.White;
            this.manageBookings.Location = new System.Drawing.Point(55, 241);
            this.manageBookings.Name = "manageBookings";
            this.manageBookings.Size = new System.Drawing.Size(199, 47);
            this.manageBookings.TabIndex = 5;
            this.manageBookings.Text = "Bookings";
            this.manageBookings.UseVisualStyleBackColor = false;
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.logOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOut.FlatAppearance.BorderSize = 0;
            this.logOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.logOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOut.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.ForeColor = System.Drawing.Color.White;
            this.logOut.Location = new System.Drawing.Point(55, 319);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(199, 47);
            this.logOut.TabIndex = 6;
            this.logOut.Text = "Logout";
            this.logOut.UseVisualStyleBackColor = false;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.manageBookings);
            this.Controls.Add(this.manageUsers);
            this.Controls.Add(this.manageEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewParticipants);
            this.Controls.Add(this.dataGridViewEvents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.DataGridView dataGridViewParticipants;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button manageEvents;
        private System.Windows.Forms.Button manageUsers;
        private System.Windows.Forms.Button manageBookings;
        private System.Windows.Forms.Button logOut;
    }
}