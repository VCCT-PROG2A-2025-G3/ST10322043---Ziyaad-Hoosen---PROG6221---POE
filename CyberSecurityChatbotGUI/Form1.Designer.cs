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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.lblFeedback = new System.Windows.Forms.Label();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.rdoOption4 = new System.Windows.Forms.RadioButton();
            this.rdoOption3 = new System.Windows.Forms.RadioButton();
            this.rdoOption2 = new System.Windows.Forms.RadioButton();
            this.rdoOption1 = new System.Windows.Forms.RadioButton();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.pnlLanding = new System.Windows.Forms.Panel();
            this.btnGoToLog = new System.Windows.Forms.Button();
            this.btnGoToChat = new System.Windows.Forms.Button();
            this.btnGoToQuiz = new System.Windows.Forms.Button();
            this.btnGoToTasks = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.lblCyberSecCB = new System.Windows.Forms.Label();
            this.pnlNavChat = new System.Windows.Forms.Panel();
            this.btnNavLog_Chat = new System.Windows.Forms.Button();
            this.btnNavQuiz_Chat = new System.Windows.Forms.Button();
            this.btnNavTasks_Chat = new System.Windows.Forms.Button();
            this.btnNavChat_Chat = new System.Windows.Forms.Button();
            this.btnNavHome_Chat = new System.Windows.Forms.Button();
            this.pnlTasks = new System.Windows.Forms.Panel();
            this.pnlNavTasks = new System.Windows.Forms.Panel();
            this.btnNavLog = new System.Windows.Forms.Button();
            this.btnNavQuiz = new System.Windows.Forms.Button();
            this.btnNavTasks = new System.Windows.Forms.Button();
            this.btnNavChat = new System.Windows.Forms.Button();
            this.btnNavHome = new System.Windows.Forms.Button();
            this.pnlQuiz = new System.Windows.Forms.Panel();
            this.pnlNavQuiz = new System.Windows.Forms.Panel();
            this.btnNavLog_Quiz = new System.Windows.Forms.Button();
            this.btnNavQuiz_Quiz = new System.Windows.Forms.Button();
            this.btnNavTasks_Quiz = new System.Windows.Forms.Button();
            this.btnNavChat_Quiz = new System.Windows.Forms.Button();
            this.btnNavHome_Quiz = new System.Windows.Forms.Button();
            this.btnStartQuiz = new System.Windows.Forms.Button();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.pnlNavLog = new System.Windows.Forms.Panel();
            this.btnNavLog_Log = new System.Windows.Forms.Button();
            this.btnNavQuiz_Log = new System.Windows.Forms.Button();
            this.btnNavTasks_Log = new System.Windows.Forms.Button();
            this.btnNavChat_Log = new System.Windows.Forms.Button();
            this.btnNavHome_Log = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.lblAssist = new System.Windows.Forms.Label();
            this.grpQuiz.SuspendLayout();
            this.pnlLanding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlChat.SuspendLayout();
            this.pnlNavChat.SuspendLayout();
            this.pnlTasks.SuspendLayout();
            this.pnlNavTasks.SuspendLayout();
            this.pnlQuiz.SuspendLayout();
            this.pnlNavQuiz.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlNavLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(211, 161);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(251, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Task Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(211, 245);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(251, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reminder:";
            // 
            // dtpReminder
            // 
            this.dtpReminder.CustomFormat = "dd MMM yyyy hh:mm tt";
            this.dtpReminder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminder.Location = new System.Drawing.Point(211, 350);
            this.dtpReminder.Name = "dtpReminder";
            this.dtpReminder.Size = new System.Drawing.Size(251, 26);
            this.dtpReminder.TabIndex = 5;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(392, 407);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(152, 32);
            this.btnAddTask.TabIndex = 6;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnDeletTask
            // 
            this.btnDeletTask.Location = new System.Drawing.Point(588, 407);
            this.btnDeletTask.Name = "btnDeletTask";
            this.btnDeletTask.Size = new System.Drawing.Size(163, 32);
            this.btnDeletTask.TabIndex = 7;
            this.btnDeletTask.Text = "Delete Selected";
            this.btnDeletTask.UseVisualStyleBackColor = true;
            this.btnDeletTask.Click += new System.EventHandler(this.btnDeletTask_Click);
            // 
            // btnMarkComplete
            // 
            this.btnMarkComplete.Location = new System.Drawing.Point(786, 407);
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
            this.taskListBox.Location = new System.Drawing.Point(319, 496);
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
            this.chatHistoryBox.Location = new System.Drawing.Point(28, 193);
            this.chatHistoryBox.Name = "chatHistoryBox";
            this.chatHistoryBox.ReadOnly = true;
            this.chatHistoryBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatHistoryBox.Size = new System.Drawing.Size(1296, 280);
            this.chatHistoryBox.TabIndex = 10;
            this.chatHistoryBox.Text = "";
            // 
            // userInputBox
            // 
            this.userInputBox.Location = new System.Drawing.Point(28, 545);
            this.userInputBox.Name = "userInputBox";
            this.userInputBox.Size = new System.Drawing.Size(1296, 26);
            this.userInputBox.TabIndex = 11;
            this.userInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userInputBox_KeyDown);
            // 
            // grpQuiz
            // 
            this.grpQuiz.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpQuiz.Controls.Add(this.lblFeedback);
            this.grpQuiz.Controls.Add(this.btnSubmitAnswer);
            this.grpQuiz.Controls.Add(this.rdoOption4);
            this.grpQuiz.Controls.Add(this.rdoOption3);
            this.grpQuiz.Controls.Add(this.rdoOption2);
            this.grpQuiz.Controls.Add(this.rdoOption1);
            this.grpQuiz.Controls.Add(this.lblQuestion);
            this.grpQuiz.Location = new System.Drawing.Point(297, 177);
            this.grpQuiz.Name = "grpQuiz";
            this.grpQuiz.Size = new System.Drawing.Size(650, 421);
            this.grpQuiz.TabIndex = 12;
            this.grpQuiz.TabStop = false;
            this.grpQuiz.Text = "Cybersecurity Quiz";
            this.grpQuiz.Visible = false;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(108, 363);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(194, 20);
            this.lblFeedback.TabIndex = 7;
            this.lblFeedback.Text = "Feedback will appear here";
            // 
            // btnSubmitAnswer
            // 
            this.btnSubmitAnswer.Location = new System.Drawing.Point(22, 327);
            this.btnSubmitAnswer.Name = "btnSubmitAnswer";
            this.btnSubmitAnswer.Size = new System.Drawing.Size(106, 28);
            this.btnSubmitAnswer.TabIndex = 5;
            this.btnSubmitAnswer.Text = "Submit Answer";
            this.btnSubmitAnswer.UseVisualStyleBackColor = true;
            this.btnSubmitAnswer.Click += new System.EventHandler(this.btnSubmitAnswer_Click);
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
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(6, 54);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(199, 20);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Questions will appear here:";
            // 
            // pnlLanding
            // 
            this.pnlLanding.Controls.Add(this.btnGoToLog);
            this.pnlLanding.Controls.Add(this.btnGoToChat);
            this.pnlLanding.Controls.Add(this.btnGoToQuiz);
            this.pnlLanding.Controls.Add(this.btnGoToTasks);
            this.pnlLanding.Controls.Add(this.picLogo);
            this.pnlLanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLanding.Location = new System.Drawing.Point(0, 0);
            this.pnlLanding.Name = "pnlLanding";
            this.pnlLanding.Size = new System.Drawing.Size(1367, 638);
            this.pnlLanding.TabIndex = 13;
            this.pnlLanding.Visible = false;
            // 
            // btnGoToLog
            // 
            this.btnGoToLog.Location = new System.Drawing.Point(614, 504);
            this.btnGoToLog.Name = "btnGoToLog";
            this.btnGoToLog.Size = new System.Drawing.Size(179, 56);
            this.btnGoToLog.TabIndex = 4;
            this.btnGoToLog.Text = "Activity Log";
            this.btnGoToLog.UseVisualStyleBackColor = true;
            // 
            // btnGoToChat
            // 
            this.btnGoToChat.Location = new System.Drawing.Point(614, 425);
            this.btnGoToChat.Name = "btnGoToChat";
            this.btnGoToChat.Size = new System.Drawing.Size(179, 56);
            this.btnGoToChat.TabIndex = 3;
            this.btnGoToChat.Text = "ChatBot";
            this.btnGoToChat.UseVisualStyleBackColor = true;
            // 
            // btnGoToQuiz
            // 
            this.btnGoToQuiz.Location = new System.Drawing.Point(614, 350);
            this.btnGoToQuiz.Name = "btnGoToQuiz";
            this.btnGoToQuiz.Size = new System.Drawing.Size(179, 56);
            this.btnGoToQuiz.TabIndex = 2;
            this.btnGoToQuiz.Text = "Quiz";
            this.btnGoToQuiz.UseVisualStyleBackColor = true;
            // 
            // btnGoToTasks
            // 
            this.btnGoToTasks.Location = new System.Drawing.Point(614, 280);
            this.btnGoToTasks.Name = "btnGoToTasks";
            this.btnGoToTasks.Size = new System.Drawing.Size(179, 56);
            this.btnGoToTasks.TabIndex = 1;
            this.btnGoToTasks.Text = "Tasks";
            this.btnGoToTasks.UseVisualStyleBackColor = true;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(573, 60);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(246, 186);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlChat
            // 
            this.pnlChat.Controls.Add(this.lblAssist);
            this.pnlChat.Controls.Add(this.lblCyberSecCB);
            this.pnlChat.Controls.Add(this.pnlNavChat);
            this.pnlChat.Controls.Add(this.userInputBox);
            this.pnlChat.Controls.Add(this.chatHistoryBox);
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChat.Location = new System.Drawing.Point(0, 0);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(1367, 638);
            this.pnlChat.TabIndex = 5;
            // 
            // lblCyberSecCB
            // 
            this.lblCyberSecCB.AutoSize = true;
            this.lblCyberSecCB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCyberSecCB.Location = new System.Drawing.Point(28, 151);
            this.lblCyberSecCB.Name = "lblCyberSecCB";
            this.lblCyberSecCB.Size = new System.Drawing.Size(293, 20);
            this.lblCyberSecCB.TabIndex = 13;
            this.lblCyberSecCB.Text = "Welcome to the CyberSecurity Chatbox! ";
            // 
            // pnlNavChat
            // 
            this.pnlNavChat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNavChat.Controls.Add(this.btnNavLog_Chat);
            this.pnlNavChat.Controls.Add(this.btnNavQuiz_Chat);
            this.pnlNavChat.Controls.Add(this.btnNavTasks_Chat);
            this.pnlNavChat.Controls.Add(this.btnNavChat_Chat);
            this.pnlNavChat.Controls.Add(this.btnNavHome_Chat);
            this.pnlNavChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavChat.Location = new System.Drawing.Point(0, 0);
            this.pnlNavChat.Name = "pnlNavChat";
            this.pnlNavChat.Size = new System.Drawing.Size(1367, 100);
            this.pnlNavChat.TabIndex = 12;
            // 
            // btnNavLog_Chat
            // 
            this.btnNavLog_Chat.Location = new System.Drawing.Point(657, 31);
            this.btnNavLog_Chat.Name = "btnNavLog_Chat";
            this.btnNavLog_Chat.Size = new System.Drawing.Size(155, 42);
            this.btnNavLog_Chat.TabIndex = 4;
            this.btnNavLog_Chat.Text = "Log";
            this.btnNavLog_Chat.UseVisualStyleBackColor = true;
            this.btnNavLog_Chat.Click += new System.EventHandler(this.btnNavLog_Click);
            // 
            // btnNavQuiz_Chat
            // 
            this.btnNavQuiz_Chat.Location = new System.Drawing.Point(495, 31);
            this.btnNavQuiz_Chat.Name = "btnNavQuiz_Chat";
            this.btnNavQuiz_Chat.Size = new System.Drawing.Size(155, 42);
            this.btnNavQuiz_Chat.TabIndex = 3;
            this.btnNavQuiz_Chat.Text = "Quiz";
            this.btnNavQuiz_Chat.UseVisualStyleBackColor = true;
            this.btnNavQuiz_Chat.Click += new System.EventHandler(this.btnNavQuiz_Click);
            // 
            // btnNavTasks_Chat
            // 
            this.btnNavTasks_Chat.Location = new System.Drawing.Point(334, 31);
            this.btnNavTasks_Chat.Name = "btnNavTasks_Chat";
            this.btnNavTasks_Chat.Size = new System.Drawing.Size(155, 42);
            this.btnNavTasks_Chat.TabIndex = 2;
            this.btnNavTasks_Chat.Text = "Tasks";
            this.btnNavTasks_Chat.UseVisualStyleBackColor = true;
            this.btnNavTasks_Chat.Click += new System.EventHandler(this.btnNavTasks_Click);
            // 
            // btnNavChat_Chat
            // 
            this.btnNavChat_Chat.Location = new System.Drawing.Point(173, 31);
            this.btnNavChat_Chat.Name = "btnNavChat_Chat";
            this.btnNavChat_Chat.Size = new System.Drawing.Size(155, 42);
            this.btnNavChat_Chat.TabIndex = 1;
            this.btnNavChat_Chat.Text = "Chat";
            this.btnNavChat_Chat.UseVisualStyleBackColor = true;
            this.btnNavChat_Chat.Click += new System.EventHandler(this.btnNavChat_Click);
            // 
            // btnNavHome_Chat
            // 
            this.btnNavHome_Chat.Location = new System.Drawing.Point(12, 31);
            this.btnNavHome_Chat.Name = "btnNavHome_Chat";
            this.btnNavHome_Chat.Size = new System.Drawing.Size(155, 42);
            this.btnNavHome_Chat.TabIndex = 0;
            this.btnNavHome_Chat.Text = "Home";
            this.btnNavHome_Chat.UseVisualStyleBackColor = true;
            this.btnNavHome_Chat.Click += new System.EventHandler(this.btnNavHome_Click);
            // 
            // pnlTasks
            // 
            this.pnlTasks.Controls.Add(this.pnlNavTasks);
            this.pnlTasks.Controls.Add(this.label1);
            this.pnlTasks.Controls.Add(this.txtTitle);
            this.pnlTasks.Controls.Add(this.label2);
            this.pnlTasks.Controls.Add(this.txtDescription);
            this.pnlTasks.Controls.Add(this.label3);
            this.pnlTasks.Controls.Add(this.dtpReminder);
            this.pnlTasks.Controls.Add(this.btnAddTask);
            this.pnlTasks.Controls.Add(this.btnDeletTask);
            this.pnlTasks.Controls.Add(this.btnMarkComplete);
            this.pnlTasks.Controls.Add(this.taskListBox);
            this.pnlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTasks.Location = new System.Drawing.Point(0, 0);
            this.pnlTasks.Name = "pnlTasks";
            this.pnlTasks.Size = new System.Drawing.Size(1367, 638);
            this.pnlTasks.TabIndex = 12;
            // 
            // pnlNavTasks
            // 
            this.pnlNavTasks.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNavTasks.Controls.Add(this.btnNavLog);
            this.pnlNavTasks.Controls.Add(this.btnNavQuiz);
            this.pnlNavTasks.Controls.Add(this.btnNavTasks);
            this.pnlNavTasks.Controls.Add(this.btnNavChat);
            this.pnlNavTasks.Controls.Add(this.btnNavHome);
            this.pnlNavTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavTasks.Location = new System.Drawing.Point(0, 0);
            this.pnlNavTasks.Name = "pnlNavTasks";
            this.pnlNavTasks.Size = new System.Drawing.Size(1367, 100);
            this.pnlNavTasks.TabIndex = 1;
            // 
            // btnNavLog
            // 
            this.btnNavLog.Location = new System.Drawing.Point(665, 31);
            this.btnNavLog.Name = "btnNavLog";
            this.btnNavLog.Size = new System.Drawing.Size(155, 42);
            this.btnNavLog.TabIndex = 4;
            this.btnNavLog.Text = "Log";
            this.btnNavLog.UseVisualStyleBackColor = true;
            this.btnNavLog.Click += new System.EventHandler(this.btnNavLog_Click);
            // 
            // btnNavQuiz
            // 
            this.btnNavQuiz.Location = new System.Drawing.Point(504, 31);
            this.btnNavQuiz.Name = "btnNavQuiz";
            this.btnNavQuiz.Size = new System.Drawing.Size(155, 42);
            this.btnNavQuiz.TabIndex = 3;
            this.btnNavQuiz.Text = "Quiz";
            this.btnNavQuiz.UseVisualStyleBackColor = true;
            this.btnNavQuiz.Click += new System.EventHandler(this.btnNavQuiz_Click);
            // 
            // btnNavTasks
            // 
            this.btnNavTasks.Location = new System.Drawing.Point(343, 31);
            this.btnNavTasks.Name = "btnNavTasks";
            this.btnNavTasks.Size = new System.Drawing.Size(155, 42);
            this.btnNavTasks.TabIndex = 2;
            this.btnNavTasks.Text = "Tasks";
            this.btnNavTasks.UseVisualStyleBackColor = true;
            this.btnNavTasks.Click += new System.EventHandler(this.btnNavTasks_Click);
            // 
            // btnNavChat
            // 
            this.btnNavChat.Location = new System.Drawing.Point(182, 31);
            this.btnNavChat.Name = "btnNavChat";
            this.btnNavChat.Size = new System.Drawing.Size(155, 42);
            this.btnNavChat.TabIndex = 1;
            this.btnNavChat.Text = "Chat";
            this.btnNavChat.UseVisualStyleBackColor = true;
            this.btnNavChat.Click += new System.EventHandler(this.btnNavChat_Click);
            // 
            // btnNavHome
            // 
            this.btnNavHome.Location = new System.Drawing.Point(21, 31);
            this.btnNavHome.Name = "btnNavHome";
            this.btnNavHome.Size = new System.Drawing.Size(155, 42);
            this.btnNavHome.TabIndex = 0;
            this.btnNavHome.Text = "Home";
            this.btnNavHome.UseVisualStyleBackColor = true;
            this.btnNavHome.Click += new System.EventHandler(this.btnNavHome_Click);
            // 
            // pnlQuiz
            // 
            this.pnlQuiz.Controls.Add(this.pnlNavQuiz);
            this.pnlQuiz.Controls.Add(this.btnStartQuiz);
            this.pnlQuiz.Controls.Add(this.grpQuiz);
            this.pnlQuiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuiz.Location = new System.Drawing.Point(0, 0);
            this.pnlQuiz.Name = "pnlQuiz";
            this.pnlQuiz.Size = new System.Drawing.Size(1367, 638);
            this.pnlQuiz.TabIndex = 10;
            // 
            // pnlNavQuiz
            // 
            this.pnlNavQuiz.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNavQuiz.Controls.Add(this.btnNavLog_Quiz);
            this.pnlNavQuiz.Controls.Add(this.btnNavQuiz_Quiz);
            this.pnlNavQuiz.Controls.Add(this.btnNavTasks_Quiz);
            this.pnlNavQuiz.Controls.Add(this.btnNavChat_Quiz);
            this.pnlNavQuiz.Controls.Add(this.btnNavHome_Quiz);
            this.pnlNavQuiz.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavQuiz.Location = new System.Drawing.Point(0, 0);
            this.pnlNavQuiz.Name = "pnlNavQuiz";
            this.pnlNavQuiz.Size = new System.Drawing.Size(1367, 100);
            this.pnlNavQuiz.TabIndex = 13;
            // 
            // btnNavLog_Quiz
            // 
            this.btnNavLog_Quiz.Location = new System.Drawing.Point(656, 31);
            this.btnNavLog_Quiz.Name = "btnNavLog_Quiz";
            this.btnNavLog_Quiz.Size = new System.Drawing.Size(155, 42);
            this.btnNavLog_Quiz.TabIndex = 4;
            this.btnNavLog_Quiz.Text = "Log";
            this.btnNavLog_Quiz.UseVisualStyleBackColor = true;
            this.btnNavLog_Quiz.Click += new System.EventHandler(this.btnNavLog_Click);
            // 
            // btnNavQuiz_Quiz
            // 
            this.btnNavQuiz_Quiz.Location = new System.Drawing.Point(495, 31);
            this.btnNavQuiz_Quiz.Name = "btnNavQuiz_Quiz";
            this.btnNavQuiz_Quiz.Size = new System.Drawing.Size(155, 42);
            this.btnNavQuiz_Quiz.TabIndex = 3;
            this.btnNavQuiz_Quiz.Text = "Quiz";
            this.btnNavQuiz_Quiz.UseVisualStyleBackColor = true;
            this.btnNavQuiz_Quiz.Click += new System.EventHandler(this.btnNavQuiz_Click);
            // 
            // btnNavTasks_Quiz
            // 
            this.btnNavTasks_Quiz.Location = new System.Drawing.Point(334, 31);
            this.btnNavTasks_Quiz.Name = "btnNavTasks_Quiz";
            this.btnNavTasks_Quiz.Size = new System.Drawing.Size(155, 42);
            this.btnNavTasks_Quiz.TabIndex = 2;
            this.btnNavTasks_Quiz.Text = "Tasks";
            this.btnNavTasks_Quiz.UseVisualStyleBackColor = true;
            this.btnNavTasks_Quiz.Click += new System.EventHandler(this.btnNavTasks_Click);
            // 
            // btnNavChat_Quiz
            // 
            this.btnNavChat_Quiz.Location = new System.Drawing.Point(173, 31);
            this.btnNavChat_Quiz.Name = "btnNavChat_Quiz";
            this.btnNavChat_Quiz.Size = new System.Drawing.Size(155, 42);
            this.btnNavChat_Quiz.TabIndex = 1;
            this.btnNavChat_Quiz.Text = "Chat";
            this.btnNavChat_Quiz.UseVisualStyleBackColor = true;
            this.btnNavChat_Quiz.Click += new System.EventHandler(this.btnNavChat_Click);
            // 
            // btnNavHome_Quiz
            // 
            this.btnNavHome_Quiz.Location = new System.Drawing.Point(12, 31);
            this.btnNavHome_Quiz.Name = "btnNavHome_Quiz";
            this.btnNavHome_Quiz.Size = new System.Drawing.Size(155, 42);
            this.btnNavHome_Quiz.TabIndex = 0;
            this.btnNavHome_Quiz.Text = "Home";
            this.btnNavHome_Quiz.UseVisualStyleBackColor = true;
            this.btnNavHome_Quiz.Click += new System.EventHandler(this.btnNavHome_Click);
            // 
            // btnStartQuiz
            // 
            this.btnStartQuiz.Location = new System.Drawing.Point(630, 124);
            this.btnStartQuiz.Name = "btnStartQuiz";
            this.btnStartQuiz.Size = new System.Drawing.Size(94, 41);
            this.btnStartQuiz.TabIndex = 1;
            this.btnStartQuiz.Text = "Start Quiz";
            this.btnStartQuiz.UseVisualStyleBackColor = true;
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.pnlNavLog);
            this.pnlLog.Controls.Add(this.logBox);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(0, 0);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(1367, 638);
            this.pnlLog.TabIndex = 13;
            // 
            // pnlNavLog
            // 
            this.pnlNavLog.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlNavLog.Controls.Add(this.btnNavLog_Log);
            this.pnlNavLog.Controls.Add(this.btnNavQuiz_Log);
            this.pnlNavLog.Controls.Add(this.btnNavTasks_Log);
            this.pnlNavLog.Controls.Add(this.btnNavChat_Log);
            this.pnlNavLog.Controls.Add(this.btnNavHome_Log);
            this.pnlNavLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavLog.Location = new System.Drawing.Point(0, 0);
            this.pnlNavLog.Name = "pnlNavLog";
            this.pnlNavLog.Size = new System.Drawing.Size(1367, 100);
            this.pnlNavLog.TabIndex = 1;
            // 
            // btnNavLog_Log
            // 
            this.btnNavLog_Log.Location = new System.Drawing.Point(656, 31);
            this.btnNavLog_Log.Name = "btnNavLog_Log";
            this.btnNavLog_Log.Size = new System.Drawing.Size(155, 42);
            this.btnNavLog_Log.TabIndex = 4;
            this.btnNavLog_Log.Text = "Log";
            this.btnNavLog_Log.UseVisualStyleBackColor = true;
            this.btnNavLog_Log.Click += new System.EventHandler(this.btnNavLog_Click);
            // 
            // btnNavQuiz_Log
            // 
            this.btnNavQuiz_Log.Location = new System.Drawing.Point(495, 31);
            this.btnNavQuiz_Log.Name = "btnNavQuiz_Log";
            this.btnNavQuiz_Log.Size = new System.Drawing.Size(155, 42);
            this.btnNavQuiz_Log.TabIndex = 3;
            this.btnNavQuiz_Log.Text = "Quiz";
            this.btnNavQuiz_Log.UseVisualStyleBackColor = true;
            this.btnNavQuiz_Log.Click += new System.EventHandler(this.btnNavQuiz_Click);
            // 
            // btnNavTasks_Log
            // 
            this.btnNavTasks_Log.Location = new System.Drawing.Point(334, 31);
            this.btnNavTasks_Log.Name = "btnNavTasks_Log";
            this.btnNavTasks_Log.Size = new System.Drawing.Size(155, 42);
            this.btnNavTasks_Log.TabIndex = 2;
            this.btnNavTasks_Log.Text = "Tasks";
            this.btnNavTasks_Log.UseVisualStyleBackColor = true;
            this.btnNavTasks_Log.Click += new System.EventHandler(this.btnNavTasks_Click);
            // 
            // btnNavChat_Log
            // 
            this.btnNavChat_Log.Location = new System.Drawing.Point(173, 31);
            this.btnNavChat_Log.Name = "btnNavChat_Log";
            this.btnNavChat_Log.Size = new System.Drawing.Size(155, 42);
            this.btnNavChat_Log.TabIndex = 1;
            this.btnNavChat_Log.Text = "Chat";
            this.btnNavChat_Log.UseVisualStyleBackColor = true;
            this.btnNavChat_Log.Click += new System.EventHandler(this.btnNavChat_Click);
            // 
            // btnNavHome_Log
            // 
            this.btnNavHome_Log.Location = new System.Drawing.Point(12, 31);
            this.btnNavHome_Log.Name = "btnNavHome_Log";
            this.btnNavHome_Log.Size = new System.Drawing.Size(155, 42);
            this.btnNavHome_Log.TabIndex = 0;
            this.btnNavHome_Log.Text = "Home";
            this.btnNavHome_Log.UseVisualStyleBackColor = true;
            this.btnNavHome_Log.Click += new System.EventHandler(this.btnNavHome_Click);
            // 
            // logBox
            // 
            this.logBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.Location = new System.Drawing.Point(194, 124);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(745, 436);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // lblAssist
            // 
            this.lblAssist.AutoSize = true;
            this.lblAssist.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAssist.Location = new System.Drawing.Point(28, 494);
            this.lblAssist.Name = "lblAssist";
            this.lblAssist.Size = new System.Drawing.Size(207, 20);
            this.lblAssist.TabIndex = 14;
            this.lblAssist.Text = "How may i assist you today?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 638);
            this.Controls.Add(this.pnlQuiz);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlLanding);
            this.Controls.Add(this.pnlTasks);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpQuiz.ResumeLayout(false);
            this.grpQuiz.PerformLayout();
            this.pnlLanding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            this.pnlNavChat.ResumeLayout(false);
            this.pnlTasks.ResumeLayout(false);
            this.pnlTasks.PerformLayout();
            this.pnlNavTasks.ResumeLayout(false);
            this.pnlQuiz.ResumeLayout(false);
            this.pnlNavQuiz.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlNavLog.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel pnlLanding;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnGoToTasks;
        private System.Windows.Forms.Button btnGoToQuiz;
        private System.Windows.Forms.Button btnGoToLog;
        private System.Windows.Forms.Button btnGoToChat;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Panel pnlTasks;
        private System.Windows.Forms.Panel pnlQuiz;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button btnStartQuiz;
        private System.Windows.Forms.Panel pnlNavTasks;
        private System.Windows.Forms.Button btnNavTasks;
        private System.Windows.Forms.Button btnNavChat;
        private System.Windows.Forms.Button btnNavHome;
        private System.Windows.Forms.Button btnNavLog;
        private System.Windows.Forms.Button btnNavQuiz;
        private System.Windows.Forms.Panel pnlNavLog;
        private System.Windows.Forms.Button btnNavHome_Log;
        private System.Windows.Forms.Button btnNavChat_Log;
        private System.Windows.Forms.Button btnNavTasks_Log;
        private System.Windows.Forms.Button btnNavQuiz_Log;
        private System.Windows.Forms.Button btnNavLog_Log;
        private System.Windows.Forms.Panel pnlNavQuiz;
        private System.Windows.Forms.Button btnNavChat_Quiz;
        private System.Windows.Forms.Button btnNavHome_Quiz;
        private System.Windows.Forms.Button btnNavLog_Quiz;
        private System.Windows.Forms.Button btnNavQuiz_Quiz;
        private System.Windows.Forms.Button btnNavTasks_Quiz;
        private System.Windows.Forms.Panel pnlNavChat;
        private System.Windows.Forms.Button btnNavLog_Chat;
        private System.Windows.Forms.Button btnNavQuiz_Chat;
        private System.Windows.Forms.Button btnNavTasks_Chat;
        private System.Windows.Forms.Button btnNavChat_Chat;
        private System.Windows.Forms.Button btnNavHome_Chat;
        private System.Windows.Forms.Label lblCyberSecCB;
        private System.Windows.Forms.Label lblAssist;
    }
}

