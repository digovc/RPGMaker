﻿using System.IO;
using DigoFramework.Json;
using Newtonsoft.Json;

namespace Rpg.Dominio
{
    public class ArquivoRefDominio : ContainerDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirArquivo;

        private ArquivoDominio _objArquivo;

        [JsonIgnore]
        public Atributo attDirArquivo
        {
            get
            {
                if (_attDirArquivo != null)
                {
                    return _attDirArquivo;
                }

                _attDirArquivo = this.getAttDirArquivo();

                return _attDirArquivo;
            }
        }

        [JsonIgnore]
        public ArquivoDominio objArquivo
        {
            get
            {
                if (_objArquivo != null)
                {
                    return _objArquivo;
                }

                _objArquivo = this.getObjArquivo();

                return _objArquivo;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal void salvarArqRef()
        {
            if (this.objArquivo == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.attDirArquivo.strValor))
            {
                return;
            }

            File.WriteAllText(this.attDirArquivo.strValor, Json.i.toJson(this.objArquivo));
        }

        private Atributo getAttDirArquivo()
        {
            Atributo attResultado = this.getAtt("Diretório");

            attResultado.strValor = this.getDirArquivo();

            return attResultado;
        }

        private string getDirArquivo()
        {
            string strResultado = (this.attNome.strValor + ".json");

            RpgDominioBase objDominioPai = this.objDominioPai;

            while (objDominioPai != null && !(objDominioPai is JogoDominio))
            {
                strResultado = string.Format("{0}/{1}", objDominioPai.attNome.strValor, strResultado);

                objDominioPai = objDominioPai.objDominioPai;
            }

            return Path.Combine(Path.GetDirectoryName(AppRpg.i.objJogo.attDirCompleto.strValor), strResultado);
        }

        private ArquivoDominio getObjArquivo()
        {
            if (string.IsNullOrEmpty(this.attDirArquivo.strValor))
            {
                return null;
            }

            if (!File.Exists(this.attDirArquivo.strValor))
            {
                return null;
            }

            return Json.i.fromJson<ArquivoDominio>(File.ReadAllText(this.attDirArquivo.strValor));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}