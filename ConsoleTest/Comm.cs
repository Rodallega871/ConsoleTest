using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 共通処理
    /// </summary>
    static class Comm
    {
        //定数
        //方位数(置きたい石の周り方位の数)
        internal static readonly int StnOrientCount = 7;
        //Enterキー確認用
        internal static readonly String EnterKey = "Enter";
        //上キー確認用
        internal static readonly String UpKey = "UpArrow";
        //下キー確認用
        internal static readonly String DownKey = "DownArrow";
        //下キー確認用
        internal static readonly String PassEnter = "pass";
        //(Enum)対戦相手がCPかどうかによって値を変更する。
        internal enum TaisenCode 
        {
            UserDousi,BlackCPU,WhiteCPU
        }

        /// <summary>
        /// アルファベットを数字に変換する。
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        static public int ToInt(this string self)
        {
            int result = 0;
            if (string.IsNullOrEmpty(self)) return result;

            char[] chars = self.ToCharArray();
            int len = self.Length - 1;
            foreach (var c in chars)
            {
                int asc = (int)c - 97;
                if (asc < 0 || asc > 26) return -1;
                result += asc * (int)Math.Pow((double)26, (double)len--);
            }
            return result;
        }

        /// <summary>
        /// 対象の列、行を受け取り8×8の盤の中に収まっていることを確認する。
        /// </summary>
        /// <param name="prmRetsu"></param>
        /// <param name="prmGyou"></param>
        /// <returns></returns>
        static public bool ChkInnerOseroBan(int prmRetsu,int prmGyou)
        {
            if (prmRetsu >= 0 && prmRetsu < 8 && prmGyou >= 0 && prmGyou < 8)
            {
                return true;
            }
            return false;
        }

    }
}
