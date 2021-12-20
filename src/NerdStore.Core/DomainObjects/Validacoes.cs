using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NerdStore.Core.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarSeIgual(object objeto1, object objeto2, string mensagem)
        {
            if (objeto1.Equals(objeto2))
                throw new DomainException(mensagem);
        }

        public static void ValidarSeDiferente(object objeto1, object objeto2, string mensagem)
        {
            if (!objeto1.Equals(objeto2))
                throw new DomainException(mensagem);
        }

        public static void ValidarCaracteres(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarCaracteres(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarExpressao(string padrao, string valor, string mensagem)
        {
            var regex = new Regex(padrao);
            if (!regex.IsMatch(valor))
                throw new DomainException(mensagem);
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeNulo(object objeto, string mensagem)
        {
            if (objeto == null)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor <= minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeFalso(bool boolValor, string mensagem)
        {
            if (!boolValor)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeVerdadeiro(bool boolValor, string mensagem)
        {
            if (boolValor)
                throw new DomainException(mensagem);
        }
    }
}
