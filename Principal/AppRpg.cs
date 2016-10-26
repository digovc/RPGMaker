﻿using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DigoFramework;
using Rpg.Dominio;
using Rpg.Frm;

namespace Rpg
{
    public class AppRpg : AppBase
    {
        #region Constantes

        internal static string STR_EXTENSAO_JOGO = ".rpggamejson";
        internal static string STR_EXTENSAO_MAPA = ".rpgmapjson";
        internal static string STR_EXTENSAO_PERSONAGEM = ".rpgpersonjson";

        #endregion Constantes

        #region Atributos

        private static AppRpg _i;

        private FrmPrincipal _frmPrincipal;
        private List<Bitmap> _lstBmpCache;
        private JogoDominio _objJogo;

        public new static AppRpg i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new AppRpg();

                return _i;
            }
        }

        public new FrmPrincipal frmPrincipal
        {
            get
            {
                return _frmPrincipal;
            }

            set
            {
                if (_frmPrincipal == value)
                {
                    return;
                }

                _frmPrincipal = value;

                this.setFrmPrincipal(_frmPrincipal);
            }
        }

        public List<Bitmap> lstBmpCache
        {
            get
            {
                if (_lstBmpCache != null)
                {
                    return _lstBmpCache;
                }

                _lstBmpCache = new List<Bitmap>();

                return _lstBmpCache;
            }
        }

        public JogoDominio objJogo
        {
            get
            {
                return _objJogo;
            }

            private set
            {
                _objJogo = value;
            }
        }

        #endregion Atributos

        #region Construtores

        private AppRpg() : base("RPG Maker (Virtual Table Top)")
        {
        }

        #endregion Construtores

        #region Métodos

        public Bitmap getBmpCache(string dirImg)
        {
            if (string.IsNullOrEmpty(dirImg))
            {
                return null;
            }

            foreach (Bitmap bmp in this.lstBmpCache)
            {
                if (!dirImg.Equals(bmp.Tag))
                {
                    continue;
                }

                return bmp;
            }

            if (!File.Exists(dirImg))
            {
                return null;
            }

            Bitmap bmpNovo = new Bitmap(dirImg);

            bmpNovo.Tag = dirImg;

            this.lstBmpCache.Add(bmpNovo);

            return bmpNovo;
        }

        internal void abrirJogo(string dirJogo)
        {
            if (string.IsNullOrEmpty(dirJogo))
            {
                return;
            }

            if (!File.Exists(dirJogo))
            {
                return;
            }

            this.objJogo = JsonRpg.i.fromJson<JogoDominio>(File.ReadAllText(dirJogo));

            if (objJogo == null)
            {
                return;
            }

            objJogo.attDirCompleto.strValor = dirJogo;
            objJogo.attStrNome.strValor = Path.GetFileNameWithoutExtension(dirJogo);

            objJogo.iniciar(false);
        }

        internal void criarJogo(string dirJogo)
        {
            if (string.IsNullOrEmpty(dirJogo))
            {
                return;
            }

            this.objJogo = JogoDominio.criar(dirJogo);

            this.objJogo.salvar();
        }

        protected override TemaBase getObjTema()
        {
            return TemaRpg.i;
        }

        private void setFrmPrincipal(FrmPrincipal frmPrincipal)
        {
            base.frmPrincipal = frmPrincipal;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}