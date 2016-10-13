﻿using System;
using System.IO;
using System.Windows.Forms;
using DigoFramework;
using DigoFramework.Json;
using Rpg.Dominio;

namespace Rpg.Controle.TabDock
{
    public partial class TabDockExplorer : TabDockRpgBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public TabDockExplorer()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void addItemMapa()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            MapaDominio objMapa = new MapaDominio();


            objMapa.attNome.strValor = "Mapa desconhecido";

            objMapa.iniciar();

            ArquivoRefDominio objArqRef = new ArquivoRefDominio();

            objArqRef.attNome.strValor = objMapa.attNome.strValor;

            this.addItem(objArqRef);

            Directory.CreateDirectory(Path.GetDirectoryName(objArqRef.attDirArquivo.strValor));

            File.WriteAllText(objArqRef.attDirArquivo.strValor, Json.i.toJson(objMapa));
        }

        internal void carregarJogo()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            this.trv.Nodes.Clear();

            TreeNodeRpg trnJogo = new TreeNodeRpg(AppRpg.i.objJogo);

            this.trv.Nodes.Add(trnJogo);

            foreach (RpgDominioBase objDominio in AppRpg.i.objJogo.lstObjFilho)
            {
                if (objDominio == null)
                {
                    continue;
                }

                objDominio.objDominioPai = AppRpg.i.objJogo;

                this.carregarJogo(objDominio, trnJogo);
            }
        }

        private void addItem()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.cmsAddItem.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void addItem(RpgDominioBase objDominio)
        {
            if (objDominio == null)
            {
                return;
            }

            if (this.trv.SelectedNode == null)
            {
                return;
            }

            if (!(this.trv.SelectedNode is TreeNodeRpg))
            {
                return;
            }

            if ((this.trv.SelectedNode as TreeNodeRpg).objDominio == null)
            {
                return;
            }

            if (!((this.trv.SelectedNode as TreeNodeRpg).objDominio is ContainerDominioBase))
            {
                return;
            }

            ContainerDominioBase objContainer = ((this.trv.SelectedNode as TreeNodeRpg).objDominio as ContainerDominioBase);

            if (!objContainer.validarItem(objDominio))
            {
                return;
            }

            objContainer.addFilho(objDominio);

            this.addTrn(new TreeNodeRpg(objDominio));
        }

        private void addItemGrupo()
        {
            if (AppRpg.i.objJogo == null)
            {
                return;
            }

            this.addItem(new GrupoDominio());
        }

        private void addTrn(TreeNodeRpg trn)
        {
            if (this.trv.SelectedNode == null)
            {
                return;
            }

            this.trv.SelectedNode.Nodes.Add(trn);

            this.trv.SelectedNode = trn;
        }

        private void processarNodeClick(TreeNodeRpg trn)
        {
            if (trn == null)
            {
                return;
            }

            AppRpg.i.frmPrincipal.objDominioSelecionado = trn.objDominio;
        }

        private void carregarJogo(RpgDominioBase objDominio, TreeNodeRpg trn)
        {
            if (objDominio == null)
            {
                return;
            }

            TreeNodeRpg trnFilho = new TreeNodeRpg(objDominio);

            trn.Nodes.Add(trnFilho);

            if (!(typeof(ContainerDominioBase).IsAssignableFrom(objDominio.GetType())))
            {
                return;
            }

            foreach (RpgDominioBase objDominioFilho in (objDominio as ContainerDominioBase).lstObjFilho)
            {
                if (objDominioFilho == null)
                {
                    continue;
                }

                objDominioFilho.objDominioPai = objDominio;

                this.carregarJogo(objDominioFilho, trnFilho);
            }
        }

        private void processarNodeDoubleClick(TreeNodeRpg trn)
        {
            if (trn == null)
            {
                return;
            }

            if (trn.objDominio == null)
            {
                return;
            }

            if (trn.objDominio is ArquivoRefDominio)
            {
                this.abrirArqRef(trn.objDominio as ArquivoRefDominio);
                return;
            }
        }

        private void abrirArqRef(ArquivoRefDominio objArqRef)
        {
            if (objArqRef == null)
            {
                return;
            }

            if (objArqRef.objArquivo == null)
            {
                return;
            }

            if (objArqRef.objArquivo is MapaDominio)
            {
                this.abrirMapa(objArqRef.objArquivo as MapaDominio);
                return;
            }
        }

        private void abrirMapa(MapaDominio objMapa)
        {
            AppRpg.i.frmPrincipal.abrirMapa(objMapa);
        }

        #endregion Métodos

        #region Eventos

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItem();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void trv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                this.processarNodeClick((TreeNodeRpg)e.Node);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void trv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            try
            {
                this.processarNodeDoubleClick((TreeNodeRpg)e.Node);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmAddItemGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItemGrupo();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void tsmAddItemMapa_Click(object sender, EventArgs e)
        {
            try
            {
                this.addItemMapa();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}