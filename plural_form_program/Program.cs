//プログラム概要
//入力された英単語を複数形に変換するプログラム
//・末尾が s, sh, ch, o, x のいずれかである英単語の末尾に es を付ける
//・末尾が f, fe のいずれかである英単語の末尾の f, fe を除き、末尾に ves を付ける
//・末尾の1文字が y で、末尾から2文字目が a, i, u, e, o のいずれでもない英単語の末尾の y を除き、末尾に ies を付ける
//・上のいずれの条件にも当てはまらない英単語の末尾には s を付ける

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace plural_form_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("単語の数を入力してね");
            var N = int.Parse(Console.ReadLine());//単語の数

            var dic = new Dictionary<string, string>(N);//単語と複数形のディクショナリ
            for (var i = 0; i < N; i++)
            {
                Console.WriteLine($"{i+1}個めの単語の数を入力してね");
                dic.Add(Console.ReadLine(), "");
            }
            var keys = dic.Keys.ToList();//ディクショナリのkeyをリスト化
            foreach(var k in keys)
            {
                var p = new Plural();
               
                dic[k]= p.Convert(k);


            }
            foreach(var d in dic)
            {
                Console.WriteLine($"{ d.Key}:{d.Value}");
                Console.WriteLine(d.Value);
            }
        }
    }
    class Plural
    {

        //頭文字を判定するメソッド
        public string Convert(string s)
        {
            var result = "";
            var rgx_1 = new Regex(@"s$|sh$|ch$|o$|x$");
            var rgx_2 = new Regex(@"f$|fe$");
            var rgx_3 = new Regex(@"y$");
            var rgx_3_op = new Regex("a|i|u|e|o");

            if (rgx_1.IsMatch(s))
            {
                result=String.Concat(s,"es");
            }else if (rgx_2.IsMatch(s))
            {
                result = rgx_2.Replace(s,"ves");
            }else if (rgx_3.IsMatch(s) && !rgx_3_op.IsMatch($"{s[s.Length-2]}"))
            {
                result = rgx_3.Replace(s, "ies");
            }
            else
            {
                result = String.Concat(s, "s");
            }
            return result;
        }

    }
}
