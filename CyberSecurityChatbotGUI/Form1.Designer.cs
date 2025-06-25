namespace CyberSecurityChatbotGUI
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnDeletTask = new System.Windows.Forms.Button();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.taskListBox = new System.Windows.Forms.ListBox();
            this.reminderTimer = new System.Windows.Forms.Timer(this.components);
            this.chatHistoryBox = new System.Windows.Forms.RichTextBox();
            this.userInputBox = new System.Windows.Forms.TextBox();
            this.grpQuiz = new System.Windows.Forms.GroupBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rdoOption1 = new System.Windows.Forms.RadioButton();
            this.rdoOption2 = new System.Windows.Forms.RadioButton();
            this.rdoOption3 = new System.Windows.Forms.RadioButton();
            this.rdoOption4 = new System.Windows.Forms.RadioButton();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.grpQuiz.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(229, 31);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Task Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(229, 111);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(251, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reminder (optional):";
            // 
            // dtpReminder
            // 
            this.dtpReminder.CustomFormat = "dd MMM yyyy hh:mm tt";
            this.dtpReminder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminder.Location = new System.Drawing.Point(229, 226);
            this.dtpReminder.Name = "dtpReminder";
            this.dtpReminder.Size = new System.Drawing.Size(251, 26);
            this.dtpReminder.TabIndex = 5;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(113, 287);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(152, 32);
            this.btnAddTask.TabIndex = 6;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnDeletTask
            // 
            this.btnDeletTask.Location = new System.Drawing.Point(340, 287);
            this.btnDeletTask.Name = "btnDeletTask";
            this.btnDeletTask.Size = new System.Drawing.Size(163, 32);
            this.btnDeletTask.TabIndex = 7;
            this.btnDeletTask.Text = "Delete Selected";
            this.btnDeletTask.UseVisualStyleBackColor = true;
            this.btnDeletTask.Click += new System.EventHandler(this.btnDeletTask_Click);
            // 
            // btnMarkComplete
            // 
            this.btnMarkComplete.Location = new System.Drawing.Point(573, 287);
            this.btnMarkComplete.Name = "btnMarkComplete";
            this.btnMarkComplete.Size = new System.Drawing.Size(153, 32);
            this.btnMarkComplete.TabIndex = 8;
            this.btnMarkComplete.Text = "Mark as Complete";
            this.btnMarkComplete.UseVisualStyleBackColor = true;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);
            // 
            // taskListBox
            // 
            this.taskListBox.FormattingEnabled = true;
            this.taskListBox.ItemHeight = 20;
            this.taskListBox.Location = new System.Drawing.Point(47, 342);
            this.taskListBox.Name = "taskListBox";
            this.taskListBox.Size = new System.Drawing.Size(704, 64);
            this.taskListBox.TabIndex = 9;
            // 
            // reminderTimer
            // 
            this.reminderTimer.Enabled = true;
            this.reminderTimer.Interval = 5000;
            this.reminderTimer.Tick += new System.EventHandler(this.reminderTimer_Tick);
            // 
            // chatHistoryBox
            // 
            this.chatHistoryBox.Location = new System.Drawing.Point(47, 519);
            this.chatHistoryBox.Name = "chatHistoryBox";
            this.chatHistoryBox.ReadOnly = true;
            this.chatHistoryBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatHistoryBox.Size = new System.Drawing.Size(704, 96);
            this.chatHistoryBox.TabIndex = 10;
            this.chatHistoryBox.Text = "";
            // 
            // userInputBox
            // 
            this.userInputBox.Location = new System.Drawing.Point(47, 470);
            this.userInputBox.Name = "userInputBox";
            this.userInputBox.Size = new System.Drawing.Size(704, 26);
            this.userInputBox.TabIndex = 11;
            // 
            // grpQuiz
            // 
            this.grpQuiz.Controls.Add(this.lblFeedback);
            this.grpQuiz.Controls.Add(this.btnSubmitAnswer);
            this.grpQuiz.Controls.Add(this.rdoOption4);
            this.grpQuiz.Controls.Add(this.rdoOption3);
            this.grpQuiz.Controls.Add(this.rdoOption2);
            this.grpQuiz.Controls.Add(this.rdoOption1);
            this.grpQuiz.Controls.Add(this.lblQuestion);
            this.grpQuiz.Location = new System.Drawing.Point(890, 60);
            this.grpQuiz.Name = "grpQuiz";
            this.grpQuiz.Size = new System.Drawing.Size(381, 421);
            this.grpQuiz.TabIndex = 12;
            this.grpQuiz.TabStop = false;
            this.grpQuiz.Text = "Cybersecurity Quiz";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(6, 54);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(199, 20);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Questions will appear here:";
            // 
            // rdoOption1
            // 
            this.rdoOption1.AutoSize = true;
            this.rdoOption1.Location = new System.Drawing.Point(10, 119);
            this.rdoOption1.Name = "rdoOption1";
            this.rdoOption1.Size = new System.Drawing.Size(94, 24);
            this.rdoOption1.TabIndex = 1;
            this.rdoOption1.TabStop = true;
            this.rdoOption1.Text = "Option 1";
            this.rdoOption1.UseVisualStyleBackColor = true;
            // 
            // rdoOption2
            // 
            this.rdoOption2.AutoSize = true;
            this.rdoOption2.Location = new System.Drawing.Point(10, 167);
            this.rdoOption2.Name = "rdoOption2";
            this.rdoOption2.Size = new System.Drawing.Size(94, 24);
            this.rdoOption2.TabIndex = 2;
            this.rdoOption2.TabStop = true;
            this.rdoOption2.Text = "Option 2";
            this.rdoOption2.UseVisualStyleBackColor = true;
            // 
            // rdoOption3
            // 
            this.rdoOption3.AutoSize = true;
            this.rdoOption3.Location = new System.Drawing.Point(10, 217);
            this.rdoOption3.Name = "rdoOption3";
            this.rdoOption3.Size = new System.Drawing.Size(98, 24);
            this.rdoOption3.TabIndex = 3;
            this.rdoOption3.TabStop = true;
            this.rdoOption3.Text = "Option 3 ";
            this.rdoOption3.UseVisualStyleBackColor = true;
            // 
            // rdoOption4
            // 
            this.rdoOption4.AutoSize = true;
            this.rdoOption4.Location = new System.Drawing.Point(10, 264);
            this.rdoOption4.Name = "rdoOption4";
            this.rdoOption4.Size = new System.Drawing.Size(94, 24);
            this.rdoOption4.TabIndex = 4;
            this.rdoOption4.TabStop = true;
            this.rdoOption4.Text = "Option 4";
            this.rdoOption4.UseVisualStyleBackColor = true;
            // 
            // btnSubmitAnswer
            // 
            this.btnSubmitAnswer.Location = new System.Drawing.Point(142, 300);
            this.btnSubmitAnswer.Name = "btnSubmitAnswer";
            this.btnSubmitAnswer.Size = new System.Drawing.Size(106, 28);
            this.btnSubmitAnswer.TabIndex = 5;
            this.btnSubmitAnswer.Text = "Submit Answer";
            this.btnSubmitAnswer.UseVisualStyleBackColor = true;
            this.btnSubmitAnswer.Click += new System.EventHandler(this.btnSubmitAnswer_Click);
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(95, 354);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(194, 20);
            this.lblFeedback.TabIndex = 7;
            this.lblFeedback.Text = "Feedback will appear here";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 638);
            this.Controls.Add(this.grpQuiz);
            this.Controls.Add(this.userInputBox);
            this.Controls.Add(this.chatHistoryBox);
            this.Controls.Add(this.taskListBox);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.btnDeletTask);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.dtpReminder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpQuiz.ResumeLayout(false);
            this.grpQuiz.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpReminder;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnDeletTask;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.ListBox taskListBox;
        private System.Windows.Forms.Timer reminderTimer;
        private System.Windows.Forms.RichTextBox chatHistoryBox;
        private System.Windows.Forms.TextBox userInputBox;
        private System.Windows.Forms.GroupBox grpQuiz;
        private System.Windows.Forms.RadioButton rdoOption1;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnSubmitAnswer;
        private System.Windows.Forms.RadioButton rdoOption4;
        private System.Windows.Forms.RadioButton rdoOption3;
        private System.Windows.Forms.RadioButton rdoOption2;
        private System.Windows.Forms.Label lblFeedback;
    }
}

