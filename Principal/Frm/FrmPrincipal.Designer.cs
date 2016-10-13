﻿namespace Rpg.Frm
{
    partial class FrmPrincipal
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
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.tsmArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmJogoAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmJogoSalvar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmJogoCriar = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExibirJogoManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExibirPropriedade = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdJogo = new System.Windows.Forms.OpenFileDialog();
            this.dcp = new DigoFramework.Controle.DockPanel.DockPanelGeral();
            this.pnlAtalho = new DigoFramework.Controle.Painel.PainelAtalho();
            this.sfdJogo = new System.Windows.Forms.SaveFileDialog();
            this.tsmCamada = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmArquivo,
            this.exibirToolStripMenuItem});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(284, 28);
            this.mnu.TabIndex = 0;
            this.mnu.Text = "menuStrip1";
            // 
            // tsmArquivo
            // 
            this.tsmArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmJogoAbrir,
            this.tsmJogoSalvar,
            this.tsmJogoCriar});
            this.tsmArquivo.Name = "tsmArquivo";
            this.tsmArquivo.Size = new System.Drawing.Size(73, 24);
            this.tsmArquivo.Text = "Arquivo";
            // 
            // tsmJogoAbrir
            // 
            this.tsmJogoAbrir.Name = "tsmJogoAbrir";
            this.tsmJogoAbrir.Size = new System.Drawing.Size(124, 26);
            this.tsmJogoAbrir.Text = "Abrir";
            this.tsmJogoAbrir.Click += new System.EventHandler(this.tsmJogoAbrir_Click);
            // 
            // tsmJogoSalvar
            // 
            this.tsmJogoSalvar.Name = "tsmJogoSalvar";
            this.tsmJogoSalvar.Size = new System.Drawing.Size(124, 26);
            this.tsmJogoSalvar.Text = "Salvar";
            this.tsmJogoSalvar.Click += new System.EventHandler(this.tsmJogoSalvar_Click);
            // 
            // tsmJogoCriar
            // 
            this.tsmJogoCriar.Name = "tsmJogoCriar";
            this.tsmJogoCriar.Size = new System.Drawing.Size(124, 26);
            this.tsmJogoCriar.Text = "Criar";
            this.tsmJogoCriar.Click += new System.EventHandler(this.tsmJogoCriar_Click);
            // 
            // exibirToolStripMenuItem
            // 
            this.exibirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExibirJogoManager,
            this.tsmExibirPropriedade,
            this.tsmCamada});
            this.exibirToolStripMenuItem.Name = "exibirToolStripMenuItem";
            this.exibirToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.exibirToolStripMenuItem.Text = "Exibir";
            // 
            // tsmExibirJogoManager
            // 
            this.tsmExibirJogoManager.Name = "tsmExibirJogoManager";
            this.tsmExibirJogoManager.Size = new System.Drawing.Size(181, 26);
            this.tsmExibirJogoManager.Text = "Jogo manager";
            // 
            // tsmExibirPropriedade
            // 
            this.tsmExibirPropriedade.Name = "tsmExibirPropriedade";
            this.tsmExibirPropriedade.Size = new System.Drawing.Size(181, 26);
            this.tsmExibirPropriedade.Text = "Propriedades";
            this.tsmExibirPropriedade.Click += new System.EventHandler(this.tsmExibirPropriedade_Click);
            // 
            // ofdJogo
            // 
            this.ofdJogo.Filter = "JSON|*.json";
            // 
            // dcp
            // 
            this.dcp.Name = "dcp";
            this.dcp.TabIndex = 1;
            // 
            // pnlAtalho
            // 
            this.pnlAtalho.Name = "pnlAtalho";
            this.pnlAtalho.TabIndex = 3;
            // 
            // sfdJogo
            // 
            this.sfdJogo.FileName = "Novo RPG.json";
            this.sfdJogo.Filter = "JSON|*.json";
            // 
            // tsmCamada
            // 
            this.tsmCamada.Name = "tsmCamada";
            this.tsmCamada.Size = new System.Drawing.Size(181, 26);
            this.tsmCamada.Text = "Camadas";
            this.tsmCamada.Click += new System.EventHandler(this.tsmCamada_Click);
            // 
            // FrmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dcp);
            this.Controls.Add(this.pnlAtalho);
            this.Controls.Add(this.mnu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnu;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem tsmArquivo;
        private DigoFramework.Controle.DockPanel.DockPanelGeral dcp;
        private DigoFramework.Controle.Painel.PainelAtalho pnlAtalho;
        private System.Windows.Forms.ToolStripMenuItem exibirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmExibirJogoManager;
        private System.Windows.Forms.ToolStripMenuItem tsmJogoCriar;
        private System.Windows.Forms.OpenFileDialog ofdJogo;
        private System.Windows.Forms.SaveFileDialog sfdJogo;
        private System.Windows.Forms.ToolStripMenuItem tsmJogoSalvar;
        private System.Windows.Forms.ToolStripMenuItem tsmJogoAbrir;
        private System.Windows.Forms.ToolStripMenuItem tsmExibirPropriedade;
        private System.Windows.Forms.ToolStripMenuItem tsmCamada;
    }
}