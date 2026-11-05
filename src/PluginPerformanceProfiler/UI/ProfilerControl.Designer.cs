namespace PluginPerformanceProfiler.UI
{
    partial class ProfilerControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRunProfilerTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportHtml = new System.Windows.Forms.ToolStripButton();
            this.btnExportCsv = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTraceAdvisor = new System.Windows.Forms.ToolStripButton();
            this.btnSponsor = new System.Windows.Forms.ToolStripButton();
            this.pnlFilterContainer = new System.Windows.Forms.Panel();
            this.tblFilters = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimeRange = new System.Windows.Forms.Label();
            this.cboTimeRange = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cboMessage = new System.Windows.Forms.ComboBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.pnlCheckboxes = new System.Windows.Forms.FlowLayoutPanel();
            this.chkSlowOnly = new System.Windows.Forms.CheckBox();
            this.chkExceptionsOnly = new System.Windows.Forms.CheckBox();
            this.chkSyncOnly = new System.Windows.Forms.CheckBox();
            this.tblCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.cardAvg = new System.Windows.Forms.Panel();
            this.lblAvgVal = new System.Windows.Forms.Label();
            this.lblAvgTitle = new System.Windows.Forms.Label();
            this.cardSlowest = new System.Windows.Forms.Panel();
            this.lblSlowestVal = new System.Windows.Forms.Label();
            this.lblSlowestTitle = new System.Windows.Forms.Label();
            this.cardFailure = new System.Windows.Forms.Panel();
            this.lblFailureVal = new System.Windows.Forms.Label();
            this.lblFailureTitle = new System.Windows.Forms.Label();
            this.cardLoops = new System.Windows.Forms.Panel();
            this.lblLoopsVal = new System.Windows.Forms.Label();
            this.lblLoopsTitle = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabSteps = new System.Windows.Forms.TabPage();
            this.dgvSteps = new System.Windows.Forms.DataGridView();
            this.tabChains = new System.Windows.Forms.TabPage();
            this.splitChains = new System.Windows.Forms.SplitContainer();
            this.dgvChains = new System.Windows.Forms.DataGridView();
            this.treeChainSteps = new System.Windows.Forms.TreeView();
            this.lblChainStepsTitle = new System.Windows.Forms.Label();
            this.tabRaw = new System.Windows.Forms.TabPage();
            this.splitRaw = new System.Windows.Forms.SplitContainer();
            this.dgvRaw = new System.Windows.Forms.DataGridView();
            this.txtTraceLogDetails = new System.Windows.Forms.TextBox();
            this.lblDetailsHeader = new System.Windows.Forms.Label();
            this.tabCompare = new System.Windows.Forms.TabPage();
            this.pnlCompareContainer = new System.Windows.Forms.Panel();
            this.txtCompareDetails = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.lblStepB = new System.Windows.Forms.Label();
            this.cboStepB = new System.Windows.Forms.ComboBox();
            this.lblStepA = new System.Windows.Forms.Label();
            this.cboStepA = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1.SuspendLayout();
            this.pnlFilterContainer.SuspendLayout();
            this.tblFilters.SuspendLayout();
            this.pnlCheckboxes.SuspendLayout();
            this.tblCards.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardAvg.SuspendLayout();
            this.cardSlowest.SuspendLayout();
            this.cardFailure.SuspendLayout();
            this.cardLoops.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
            this.tabChains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitChains)).BeginInit();
            this.splitChains.Panel1.SuspendLayout();
            this.splitChains.Panel2.SuspendLayout();
            this.splitChains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).BeginInit();
            this.tabRaw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRaw)).BeginInit();
            this.splitRaw.Panel1.SuspendLayout();
            this.splitRaw.Panel2.SuspendLayout();
            this.splitRaw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaw)).BeginInit();
            this.tabCompare.SuspendLayout();
            this.pnlCompareContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRunProfilerTool,
            this.toolStripSeparator1,
            this.btnExportHtml,
            this.btnExportCsv,
            this.toolStripSeparator2,
            this.btnTraceAdvisor,
            this.btnSponsor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.toolStrip1.Size = new System.Drawing.Size(1150, 39);
            this.toolStrip1.TabIndex = 0;
            // 
            // btnRunProfilerTool
            // 
            this.btnRunProfilerTool.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRunProfilerTool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRunProfilerTool.Name = "btnRunProfilerTool";
            this.btnRunProfilerTool.Size = new System.Drawing.Size(185, 28);
            this.btnRunProfilerTool.Text = "▶  Run Plugin Profiler";
            this.btnRunProfilerTool.Click += new System.EventHandler(this.btnRunProfiler_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnExportHtml
            // 
            this.btnExportHtml.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnExportHtml.Name = "btnExportHtml";
            this.btnExportHtml.Size = new System.Drawing.Size(190, 28);
            this.btnExportHtml.Text = "📊  Executive Report (HTML)";
            this.btnExportHtml.Click += new System.EventHandler(this.btnExportHtml_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(130, 28);
            this.btnExportCsv.Text = "📁  Export CSV Data";
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnTraceAdvisor
            // 
            this.btnTraceAdvisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnTraceAdvisor.Name = "btnTraceAdvisor";
            this.btnTraceAdvisor.Size = new System.Drawing.Size(190, 28);
            this.btnTraceAdvisor.Text = "⚙  Trace Settings Advisor";
            this.btnTraceAdvisor.Click += new System.EventHandler(this.btnTraceAdvisor_Click);
            // 
            // btnSponsor
            // 
            this.btnSponsor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSponsor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.btnSponsor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSponsor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(39)))), ((int)(((byte)(119)))));
            this.btnSponsor.Name = "btnSponsor";
            this.btnSponsor.Size = new System.Drawing.Size(160, 28);
            this.btnSponsor.Text = "💖  Sponsor / Pro";
            this.btnSponsor.ToolTipText = "Support developer on GitHub Sponsors & unlock Pro monitoring";
            this.btnSponsor.Click += new System.EventHandler(this.btnSponsor_Click);
            // 
            // pnlFilterContainer
            // 
            this.pnlFilterContainer.BackColor = System.Drawing.Color.White;
            this.pnlFilterContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterContainer.Controls.Add(this.tblFilters);
            this.pnlFilterContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterContainer.Location = new System.Drawing.Point(0, 39);
            this.pnlFilterContainer.Name = "pnlFilterContainer";
            this.pnlFilterContainer.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlFilterContainer.Size = new System.Drawing.Size(1150, 110);
            this.pnlFilterContainer.TabIndex = 1;
            // 
            // tblFilters
            // 
            this.tblFilters.ColumnCount = 6;
            this.tblFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tblFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tblFilters.Controls.Add(this.lblTimeRange, 0, 0);
            this.tblFilters.Controls.Add(this.cboTimeRange, 1, 0);
            this.tblFilters.Controls.Add(this.lblMessage, 2, 0);
            this.tblFilters.Controls.Add(this.cboMessage, 3, 0);
            this.tblFilters.Controls.Add(this.pnlCheckboxes, 4, 0);
            this.tblFilters.Controls.Add(this.btnApplyFilter, 5, 0);
            this.tblFilters.Controls.Add(this.lblEntity, 0, 1);
            this.tblFilters.Controls.Add(this.txtEntity, 1, 1);
            this.tblFilters.Controls.Add(this.lblSearch, 2, 1);
            this.tblFilters.Controls.Add(this.txtSearch, 3, 1);
            this.tblFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFilters.Location = new System.Drawing.Point(12, 6);
            this.tblFilters.Name = "tblFilters";
            this.tblFilters.RowCount = 2;
            this.tblFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblFilters.Size = new System.Drawing.Size(1124, 96);
            this.tblFilters.TabIndex = 0;
            // 
            // lblTimeRange
            // 
            this.lblTimeRange.AutoSize = true;
            this.lblTimeRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeRange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimeRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTimeRange.Location = new System.Drawing.Point(3, 0);
            this.lblTimeRange.Name = "lblTimeRange";
            this.lblTimeRange.Size = new System.Drawing.Size(94, 46);
            this.lblTimeRange.TabIndex = 0;
            this.lblTimeRange.Text = "Time Range:";
            this.lblTimeRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTimeRange
            // 
            this.cboTimeRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeRange.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTimeRange.FormattingEnabled = true;
            this.cboTimeRange.Items.AddRange(new object[] {
            "Last 1 Hour",
            "Last 6 Hours",
            "Last 24 Hours",
            "Last 3 Days (72h)",
            "Last 7 Days (168h)"});
            this.cboTimeRange.Location = new System.Drawing.Point(103, 8);
            this.cboTimeRange.Name = "cboTimeRange";
            this.cboTimeRange.Size = new System.Drawing.Size(248, 29);
            this.cboTimeRange.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMessage.Location = new System.Drawing.Point(357, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(84, 46);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message:";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMessage
            // 
            this.cboMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMessage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessage.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMessage.FormattingEnabled = true;
            this.cboMessage.Items.AddRange(new object[] {
            "ALL",
            "Create",
            "Update",
            "Delete",
            "RetrieveMultiple",
            "SetState",
            "Assign",
            "ExecuteWorkflow"});
            this.cboMessage.Location = new System.Drawing.Point(447, 8);
            this.cboMessage.Name = "cboMessage";
            this.cboMessage.Size = new System.Drawing.Size(248, 29);
            this.cboMessage.TabIndex = 3;
            // 
            // pnlCheckboxes
            // 
            this.pnlCheckboxes.Controls.Add(this.chkSlowOnly);
            this.pnlCheckboxes.Controls.Add(this.chkExceptionsOnly);
            this.pnlCheckboxes.Controls.Add(this.chkSyncOnly);
            this.pnlCheckboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckboxes.Location = new System.Drawing.Point(701, 3);
            this.pnlCheckboxes.Name = "pnlCheckboxes";
            this.pnlCheckboxes.Size = new System.Drawing.Size(249, 40);
            this.pnlCheckboxes.TabIndex = 4;
            // 
            // chkSlowOnly
            // 
            this.chkSlowOnly.AutoSize = true;
            this.chkSlowOnly.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.chkSlowOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.chkSlowOnly.Location = new System.Drawing.Point(3, 8);
            this.chkSlowOnly.Name = "chkSlowOnly";
            this.chkSlowOnly.Size = new System.Drawing.Size(95, 23);
            this.chkSlowOnly.TabIndex = 0;
            this.chkSlowOnly.Text = "Slow >2s";
            this.chkSlowOnly.UseVisualStyleBackColor = true;
            // 
            // chkExceptionsOnly
            // 
            this.chkExceptionsOnly.AutoSize = true;
            this.chkExceptionsOnly.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkExceptionsOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkExceptionsOnly.Location = new System.Drawing.Point(104, 8);
            this.chkExceptionsOnly.Name = "chkExceptionsOnly";
            this.chkExceptionsOnly.Size = new System.Drawing.Size(89, 23);
            this.chkExceptionsOnly.TabIndex = 1;
            this.chkExceptionsOnly.Text = "Failures";
            this.chkExceptionsOnly.UseVisualStyleBackColor = true;
            // 
            // chkSyncOnly
            // 
            this.chkSyncOnly.AutoSize = true;
            this.chkSyncOnly.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkSyncOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkSyncOnly.Location = new System.Drawing.Point(3, 37);
            this.chkSyncOnly.Name = "chkSyncOnly";
            this.chkSyncOnly.Size = new System.Drawing.Size(60, 23);
            this.chkSyncOnly.TabIndex = 2;
            this.chkSyncOnly.Text = "Sync";
            this.chkSyncOnly.UseVisualStyleBackColor = true;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyFilter.FlatAppearance.BorderSize = 0;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(956, 5);
            this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.tblFilters.SetRowSpan(this.btnApplyFilter, 2);
            this.btnApplyFilter.Size = new System.Drawing.Size(165, 84);
            this.btnApplyFilter.TabIndex = 5;
            this.btnApplyFilter.Text = "🔍  Load & Profile";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEntity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEntity.Location = new System.Drawing.Point(3, 46);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(94, 50);
            this.lblEntity.TabIndex = 6;
            this.lblEntity.Text = "Entity Filter:";
            this.lblEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEntity
            // 
            this.txtEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntity.BackColor = System.Drawing.Color.White;
            this.txtEntity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtEntity.Location = new System.Drawing.Point(103, 56);
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.Size = new System.Drawing.Size(248, 29);
            this.txtEntity.TabIndex = 7;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSearch.Location = new System.Drawing.Point(357, 46);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(84, 50);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Plugin Search:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblFilters.SetColumnSpan(this.txtSearch, 2);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtSearch.Location = new System.Drawing.Point(447, 56);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(503, 29);
            this.txtSearch.TabIndex = 9;
            // 
            // tblCards
            // 
            this.tblCards.ColumnCount = 5;
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCards.Controls.Add(this.cardLoops, 4, 0);
            this.tblCards.Controls.Add(this.cardFailure, 3, 0);
            this.tblCards.Controls.Add(this.cardSlowest, 2, 0);
            this.tblCards.Controls.Add(this.cardAvg, 1, 0);
            this.tblCards.Controls.Add(this.cardTotal, 0, 0);
            this.tblCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblCards.Location = new System.Drawing.Point(0, 149);
            this.tblCards.Name = "tblCards";
            this.tblCards.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.tblCards.RowCount = 1;
            this.tblCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCards.Size = new System.Drawing.Size(1150, 72);
            this.tblCards.TabIndex = 2;
            // 
            // cardTotal
            // 
            this.cardTotal.BackColor = System.Drawing.Color.White;
            this.cardTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotal.Controls.Add(this.lblTotalVal);
            this.cardTotal.Controls.Add(this.lblTotalTitle);
            this.cardTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotal.Location = new System.Drawing.Point(15, 9);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cardTotal.Size = new System.Drawing.Size(219, 54);
            this.cardTotal.TabIndex = 0;
            // 
            // lblTotalVal
            // 
            this.lblTotalVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTotalVal.Location = new System.Drawing.Point(6, 21);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(205, 27);
            this.lblTotalVal.TabIndex = 1;
            this.lblTotalVal.Text = "—";
            this.lblTotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(6, 4);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(205, 17);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "TOTAL EXECUTIONS";
            this.lblTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardAvg
            // 
            this.cardAvg.BackColor = System.Drawing.Color.White;
            this.cardAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardAvg.Controls.Add(this.lblAvgVal);
            this.cardAvg.Controls.Add(this.lblAvgTitle);
            this.cardAvg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardAvg.Location = new System.Drawing.Point(240, 9);
            this.cardAvg.Name = "cardAvg";
            this.cardAvg.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cardAvg.Size = new System.Drawing.Size(219, 54);
            this.cardAvg.TabIndex = 1;
            // 
            // lblAvgVal
            // 
            this.lblAvgVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvgVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvgVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblAvgVal.Location = new System.Drawing.Point(6, 21);
            this.lblAvgVal.Name = "lblAvgVal";
            this.lblAvgVal.Size = new System.Drawing.Size(205, 27);
            this.lblAvgVal.TabIndex = 1;
            this.lblAvgVal.Text = "—";
            this.lblAvgVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgTitle
            // 
            this.lblAvgTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvgTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblAvgTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAvgTitle.Location = new System.Drawing.Point(6, 4);
            this.lblAvgTitle.Name = "lblAvgTitle";
            this.lblAvgTitle.Size = new System.Drawing.Size(205, 17);
            this.lblAvgTitle.TabIndex = 0;
            this.lblAvgTitle.Text = "AVG LATENCY";
            this.lblAvgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardSlowest
            // 
            this.cardSlowest.BackColor = System.Drawing.Color.White;
            this.cardSlowest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardSlowest.Controls.Add(this.lblSlowestVal);
            this.cardSlowest.Controls.Add(this.lblSlowestTitle);
            this.cardSlowest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardSlowest.Location = new System.Drawing.Point(465, 9);
            this.cardSlowest.Name = "cardSlowest";
            this.cardSlowest.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cardSlowest.Size = new System.Drawing.Size(219, 54);
            this.cardSlowest.TabIndex = 2;
            // 
            // lblSlowestVal
            // 
            this.lblSlowestVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSlowestVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSlowestVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblSlowestVal.Location = new System.Drawing.Point(6, 21);
            this.lblSlowestVal.Name = "lblSlowestVal";
            this.lblSlowestVal.Size = new System.Drawing.Size(205, 27);
            this.lblSlowestVal.TabIndex = 1;
            this.lblSlowestVal.Text = "—";
            this.lblSlowestVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSlowestTitle
            // 
            this.lblSlowestTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSlowestTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSlowestTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSlowestTitle.Location = new System.Drawing.Point(6, 4);
            this.lblSlowestTitle.Name = "lblSlowestTitle";
            this.lblSlowestTitle.Size = new System.Drawing.Size(205, 17);
            this.lblSlowestTitle.TabIndex = 0;
            this.lblSlowestTitle.Text = "SLOWEST EXECUTION";
            this.lblSlowestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardFailure
            // 
            this.cardFailure.BackColor = System.Drawing.Color.White;
            this.cardFailure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardFailure.Controls.Add(this.lblFailureVal);
            this.cardFailure.Controls.Add(this.lblFailureTitle);
            this.cardFailure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardFailure.Location = new System.Drawing.Point(690, 9);
            this.cardFailure.Name = "cardFailure";
            this.cardFailure.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cardFailure.Size = new System.Drawing.Size(219, 54);
            this.cardFailure.TabIndex = 3;
            // 
            // lblFailureVal
            // 
            this.lblFailureVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFailureVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFailureVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblFailureVal.Location = new System.Drawing.Point(6, 21);
            this.lblFailureVal.Name = "lblFailureVal";
            this.lblFailureVal.Size = new System.Drawing.Size(205, 27);
            this.lblFailureVal.TabIndex = 1;
            this.lblFailureVal.Text = "—";
            this.lblFailureVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFailureTitle
            // 
            this.lblFailureTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFailureTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblFailureTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFailureTitle.Location = new System.Drawing.Point(6, 4);
            this.lblFailureTitle.Name = "lblFailureTitle";
            this.lblFailureTitle.Size = new System.Drawing.Size(205, 17);
            this.lblFailureTitle.TabIndex = 0;
            this.lblFailureTitle.Text = "FAILURE RATE";
            this.lblFailureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardLoops
            // 
            this.cardLoops.BackColor = System.Drawing.Color.White;
            this.cardLoops.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardLoops.Controls.Add(this.lblLoopsVal);
            this.cardLoops.Controls.Add(this.lblLoopsTitle);
            this.cardLoops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardLoops.Location = new System.Drawing.Point(915, 9);
            this.cardLoops.Name = "cardLoops";
            this.cardLoops.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cardLoops.Size = new System.Drawing.Size(220, 54);
            this.cardLoops.TabIndex = 4;
            // 
            // lblLoopsVal
            // 
            this.lblLoopsVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoopsVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoopsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblLoopsVal.Location = new System.Drawing.Point(6, 21);
            this.lblLoopsVal.Name = "lblLoopsVal";
            this.lblLoopsVal.Size = new System.Drawing.Size(206, 27);
            this.lblLoopsVal.TabIndex = 1;
            this.lblLoopsVal.Text = "—";
            this.lblLoopsVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoopsTitle
            // 
            this.lblLoopsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoopsTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblLoopsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLoopsTitle.Location = new System.Drawing.Point(6, 4);
            this.lblLoopsTitle.Name = "lblLoopsTitle";
            this.lblLoopsTitle.Size = new System.Drawing.Size(206, 17);
            this.lblLoopsTitle.TabIndex = 0;
            this.lblLoopsTitle.Text = "RECURSIONS / LOOPS";
            this.lblLoopsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabSteps);
            this.tabControlMain.Controls.Add(this.tabChains);
            this.tabControlMain.Controls.Add(this.tabRaw);
            this.tabControlMain.Controls.Add(this.tabCompare);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControlMain.Location = new System.Drawing.Point(0, 221);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1150, 427);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabSteps
            // 
            this.tabSteps.BackColor = System.Drawing.Color.White;
            this.tabSteps.Controls.Add(this.dgvSteps);
            this.tabSteps.Location = new System.Drawing.Point(4, 30);
            this.tabSteps.Name = "tabSteps";
            this.tabSteps.Padding = new System.Windows.Forms.Padding(8);
            this.tabSteps.Size = new System.Drawing.Size(1142, 393);
            this.tabSteps.TabIndex = 0;
            this.tabSteps.Text = "  🏆 Step Performance Leaderboard  ";
            // 
            // dgvSteps
            // 
            this.dgvSteps.AllowUserToAddRows = false;
            this.dgvSteps.AllowUserToDeleteRows = false;
            this.dgvSteps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSteps.BackgroundColor = System.Drawing.Color.White;
            this.dgvSteps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSteps.Location = new System.Drawing.Point(8, 8);
            this.dgvSteps.Name = "dgvSteps";
            this.dgvSteps.ReadOnly = true;
            this.dgvSteps.RowHeadersVisible = false;
            this.dgvSteps.RowHeadersWidth = 51;
            this.dgvSteps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSteps.Size = new System.Drawing.Size(1126, 377);
            this.dgvSteps.TabIndex = 0;
            this.dgvSteps.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSteps_CellDoubleClick);
            // 
            // tabChains
            // 
            this.tabChains.BackColor = System.Drawing.Color.White;
            this.tabChains.Controls.Add(this.splitChains);
            this.tabChains.Location = new System.Drawing.Point(4, 30);
            this.tabChains.Name = "tabChains";
            this.tabChains.Padding = new System.Windows.Forms.Padding(8);
            this.tabChains.Size = new System.Drawing.Size(1142, 393);
            this.tabChains.TabIndex = 1;
            this.tabChains.Text = "  🔄 Cascading Patterns & Loops  ";
            // 
            // splitChains
            // 
            this.splitChains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChains.Location = new System.Drawing.Point(8, 8);
            this.splitChains.Name = "splitChains";
            // 
            // splitChains.Panel1
            // 
            this.splitChains.Panel1.Controls.Add(this.dgvChains);
            // 
            // splitChains.Panel2
            // 
            this.splitChains.Panel2.Controls.Add(this.treeChainSteps);
            this.splitChains.Panel2.Controls.Add(this.lblChainStepsTitle);
            this.splitChains.Size = new System.Drawing.Size(1126, 377);
            this.splitChains.SplitterDistance = 640;
            this.splitChains.TabIndex = 0;
            // 
            // dgvChains
            // 
            this.dgvChains.AllowUserToAddRows = false;
            this.dgvChains.AllowUserToDeleteRows = false;
            this.dgvChains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChains.BackgroundColor = System.Drawing.Color.White;
            this.dgvChains.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChains.Location = new System.Drawing.Point(0, 0);
            this.dgvChains.Name = "dgvChains";
            this.dgvChains.ReadOnly = true;
            this.dgvChains.RowHeadersVisible = false;
            this.dgvChains.RowHeadersWidth = 51;
            this.dgvChains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChains.Size = new System.Drawing.Size(640, 377);
            this.dgvChains.TabIndex = 0;
            this.dgvChains.SelectionChanged += new System.EventHandler(this.dgvChains_SelectionChanged);
            // 
            // treeChainSteps
            // 
            this.treeChainSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeChainSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeChainSteps.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.treeChainSteps.Location = new System.Drawing.Point(0, 26);
            this.treeChainSteps.Name = "treeChainSteps";
            this.treeChainSteps.Size = new System.Drawing.Size(482, 351);
            this.treeChainSteps.TabIndex = 1;
            // 
            // lblChainStepsTitle
            // 
            this.lblChainStepsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChainStepsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChainStepsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblChainStepsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblChainStepsTitle.Name = "lblChainStepsTitle";
            this.lblChainStepsTitle.Size = new System.Drawing.Size(482, 26);
            this.lblChainStepsTitle.TabIndex = 0;
            this.lblChainStepsTitle.Text = "Execution Chain Tree & Depth Breakdown:";
            this.lblChainStepsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabRaw
            // 
            this.tabRaw.BackColor = System.Drawing.Color.White;
            this.tabRaw.Controls.Add(this.splitRaw);
            this.tabRaw.Location = new System.Drawing.Point(4, 30);
            this.tabRaw.Name = "tabRaw";
            this.tabRaw.Padding = new System.Windows.Forms.Padding(8);
            this.tabRaw.Size = new System.Drawing.Size(1142, 393);
            this.tabRaw.TabIndex = 2;
            this.tabRaw.Text = "  📋 Trace Logs & Exceptions  ";
            // 
            // splitRaw
            // 
            this.splitRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRaw.Location = new System.Drawing.Point(8, 8);
            this.splitRaw.Name = "splitRaw";
            this.splitRaw.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRaw.Panel1
            // 
            this.splitRaw.Panel1.Controls.Add(this.dgvRaw);
            // 
            // splitRaw.Panel2
            // 
            this.splitRaw.Panel2.Controls.Add(this.txtTraceLogDetails);
            this.splitRaw.Panel2.Controls.Add(this.lblDetailsHeader);
            this.splitRaw.Size = new System.Drawing.Size(1126, 377);
            this.splitRaw.SplitterDistance = 210;
            this.splitRaw.TabIndex = 0;
            // 
            // dgvRaw
            // 
            this.dgvRaw.AllowUserToAddRows = false;
            this.dgvRaw.AllowUserToDeleteRows = false;
            this.dgvRaw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRaw.BackgroundColor = System.Drawing.Color.White;
            this.dgvRaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRaw.Location = new System.Drawing.Point(0, 0);
            this.dgvRaw.Name = "dgvRaw";
            this.dgvRaw.ReadOnly = true;
            this.dgvRaw.RowHeadersVisible = false;
            this.dgvRaw.RowHeadersWidth = 51;
            this.dgvRaw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRaw.Size = new System.Drawing.Size(1126, 210);
            this.dgvRaw.TabIndex = 0;
            this.dgvRaw.SelectionChanged += new System.EventHandler(this.dgvRaw_SelectionChanged);
            // 
            // txtTraceLogDetails
            // 
            this.txtTraceLogDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTraceLogDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTraceLogDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTraceLogDetails.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtTraceLogDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtTraceLogDetails.Location = new System.Drawing.Point(0, 24);
            this.txtTraceLogDetails.Multiline = true;
            this.txtTraceLogDetails.Name = "txtTraceLogDetails";
            this.txtTraceLogDetails.ReadOnly = true;
            this.txtTraceLogDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTraceLogDetails.Size = new System.Drawing.Size(1126, 139);
            this.txtTraceLogDetails.TabIndex = 1;
            // 
            // lblDetailsHeader
            // 
            this.lblDetailsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetailsHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDetailsHeader.Location = new System.Drawing.Point(0, 0);
            this.lblDetailsHeader.Name = "lblDetailsHeader";
            this.lblDetailsHeader.Size = new System.Drawing.Size(1126, 24);
            this.lblDetailsHeader.TabIndex = 0;
            this.lblDetailsHeader.Text = "Trace Log Message & Exception Details:";
            this.lblDetailsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabCompare
            // 
            this.tabCompare.BackColor = System.Drawing.Color.White;
            this.tabCompare.Controls.Add(this.pnlCompareContainer);
            this.tabCompare.Location = new System.Drawing.Point(4, 30);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.Padding = new System.Windows.Forms.Padding(16);
            this.tabCompare.Size = new System.Drawing.Size(1142, 393);
            this.tabCompare.TabIndex = 3;
            this.tabCompare.Text = "  ⚖ Compare Performance (A vs B)  ";
            // 
            // pnlCompareContainer
            // 
            this.pnlCompareContainer.Controls.Add(this.txtCompareDetails);
            this.pnlCompareContainer.Controls.Add(this.btnCompare);
            this.pnlCompareContainer.Controls.Add(this.lblStepB);
            this.pnlCompareContainer.Controls.Add(this.cboStepB);
            this.pnlCompareContainer.Controls.Add(this.lblStepA);
            this.pnlCompareContainer.Controls.Add(this.cboStepA);
            this.pnlCompareContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompareContainer.Location = new System.Drawing.Point(16, 16);
            this.pnlCompareContainer.Name = "pnlCompareContainer";
            this.pnlCompareContainer.Size = new System.Drawing.Size(1110, 361);
            this.pnlCompareContainer.TabIndex = 0;
            // 
            // txtCompareDetails
            // 
            this.txtCompareDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompareDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtCompareDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompareDetails.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtCompareDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtCompareDetails.Location = new System.Drawing.Point(15, 95);
            this.txtCompareDetails.Multiline = true;
            this.txtCompareDetails.Name = "txtCompareDetails";
            this.txtCompareDetails.ReadOnly = true;
            this.txtCompareDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCompareDetails.Size = new System.Drawing.Size(1080, 255);
            this.txtCompareDetails.TabIndex = 5;
            // 
            // btnCompare
            // 
            this.btnCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCompare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompare.FlatAppearance.BorderSize = 0;
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCompare.ForeColor = System.Drawing.Color.White;
            this.btnCompare.Location = new System.Drawing.Point(830, 40);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(265, 36);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "⚡  Compare Execution Metrics";
            this.btnCompare.UseVisualStyleBackColor = false;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // lblStepB
            // 
            this.lblStepB.AutoSize = true;
            this.lblStepB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStepB.Location = new System.Drawing.Point(420, 15);
            this.lblStepB.Name = "lblStepB";
            this.lblStepB.Size = new System.Drawing.Size(164, 20);
            this.lblStepB.TabIndex = 3;
            this.lblStepB.Text = "Step B (Comparison):";
            // 
            // cboStepB
            // 
            this.cboStepB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStepB.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboStepB.FormattingEnabled = true;
            this.cboStepB.Location = new System.Drawing.Point(420, 44);
            this.cboStepB.Name = "cboStepB";
            this.cboStepB.Size = new System.Drawing.Size(390, 29);
            this.cboStepB.TabIndex = 2;
            // 
            // lblStepA
            // 
            this.lblStepA.AutoSize = true;
            this.lblStepA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStepA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStepA.Location = new System.Drawing.Point(15, 15);
            this.lblStepA.Name = "lblStepA";
            this.lblStepA.Size = new System.Drawing.Size(142, 20);
            this.lblStepA.TabIndex = 1;
            this.lblStepA.Text = "Step A (Baseline):";
            // 
            // cboStepA
            // 
            this.cboStepA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStepA.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboStepA.FormattingEnabled = true;
            this.cboStepA.Location = new System.Drawing.Point(15, 44);
            this.cboStepA.Name = "cboStepA";
            this.cboStepA.Size = new System.Drawing.Size(390, 29);
            this.cboStepA.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 648);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1150, 28);
            this.statusStrip1.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1135, 22);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready to profile Dataverse plugin execution performance.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 20);
            this.progressBar.Visible = false;
            // 
            // ProfilerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.tblCards);
            this.Controls.Add(this.pnlFilterContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ProfilerControl";
            this.Size = new System.Drawing.Size(1150, 676);
            this.Load += new System.EventHandler(this.ProfilerControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlFilterContainer.ResumeLayout(false);
            this.tblFilters.ResumeLayout(false);
            this.tblFilters.PerformLayout();
            this.pnlCheckboxes.ResumeLayout(false);
            this.pnlCheckboxes.PerformLayout();
            this.tblCards.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.cardAvg.ResumeLayout(false);
            this.cardSlowest.ResumeLayout(false);
            this.cardFailure.ResumeLayout(false);
            this.cardLoops.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
            this.tabChains.ResumeLayout(false);
            this.splitChains.Panel1.ResumeLayout(false);
            this.splitChains.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChains)).EndInit();
            this.splitChains.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).EndInit();
            this.tabRaw.ResumeLayout(false);
            this.splitRaw.Panel1.ResumeLayout(false);
            this.splitRaw.Panel2.ResumeLayout(false);
            this.splitRaw.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRaw)).EndInit();
            this.splitRaw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaw)).EndInit();
            this.tabCompare.ResumeLayout(false);
            this.pnlCompareContainer.ResumeLayout(false);
            this.pnlCompareContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRunProfilerTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportHtml;
        private System.Windows.Forms.ToolStripButton btnExportCsv;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnTraceAdvisor;
        private System.Windows.Forms.ToolStripButton btnSponsor;
        private System.Windows.Forms.Panel pnlFilterContainer;
        private System.Windows.Forms.TableLayoutPanel tblFilters;
        private System.Windows.Forms.Label lblTimeRange;
        private System.Windows.Forms.ComboBox cboTimeRange;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox cboMessage;
        private System.Windows.Forms.FlowLayoutPanel pnlCheckboxes;
        private System.Windows.Forms.CheckBox chkSlowOnly;
        private System.Windows.Forms.CheckBox chkExceptionsOnly;
        private System.Windows.Forms.CheckBox chkSyncOnly;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel tblCards;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Panel cardAvg;
        private System.Windows.Forms.Label lblAvgVal;
        private System.Windows.Forms.Label lblAvgTitle;
        private System.Windows.Forms.Panel cardSlowest;
        private System.Windows.Forms.Label lblSlowestVal;
        private System.Windows.Forms.Label lblSlowestTitle;
        private System.Windows.Forms.Panel cardFailure;
        private System.Windows.Forms.Label lblFailureVal;
        private System.Windows.Forms.Label lblFailureTitle;
        private System.Windows.Forms.Panel cardLoops;
        private System.Windows.Forms.Label lblLoopsVal;
        private System.Windows.Forms.Label lblLoopsTitle;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabSteps;
        private System.Windows.Forms.DataGridView dgvSteps;
        private System.Windows.Forms.TabPage tabChains;
        private System.Windows.Forms.SplitContainer splitChains;
        private System.Windows.Forms.DataGridView dgvChains;
        private System.Windows.Forms.TreeView treeChainSteps;
        private System.Windows.Forms.Label lblChainStepsTitle;
        private System.Windows.Forms.TabPage tabRaw;
        private System.Windows.Forms.SplitContainer splitRaw;
        private System.Windows.Forms.DataGridView dgvRaw;
        private System.Windows.Forms.TextBox txtTraceLogDetails;
        private System.Windows.Forms.Label lblDetailsHeader;
        private System.Windows.Forms.TabPage tabCompare;
        private System.Windows.Forms.Panel pnlCompareContainer;
        private System.Windows.Forms.ComboBox cboStepA;
        private System.Windows.Forms.Label lblStepA;
        private System.Windows.Forms.ComboBox cboStepB;
        private System.Windows.Forms.Label lblStepB;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TextBox txtCompareDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}
