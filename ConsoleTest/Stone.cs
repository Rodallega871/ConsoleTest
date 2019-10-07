using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 石の情報を持つクラス
    /// </summary>
    class Stone
    {
        //列座標
        internal int Retsu { get; set; }
        //行座標
        internal int Gyou { get; set; }
        //死活フラグ
        /*
         * 置きたい石の座標の周り7方位について
         * ひっくり返せる対象があるかどうかを判定する。
         */
        internal bool SKFlg { get; set; } = true;

        internal Stone(int prmRetsu, int prmGyou)
        {
            //セットする。
            Retsu = prmRetsu;
            Gyou = prmGyou;
        }
    }
}
