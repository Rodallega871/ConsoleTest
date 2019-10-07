using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 置きたい石及び置きたい石の周辺7方位の石の場所情報をもつ。
    /// 通称：7方位クラス
    /// </summary>
    class SevenOrient
    {
        //置きたい石
        internal Stone OkitaiStn;
        //隣石リスト保持クラスのリスト
        internal List<NextStnInfo> NextStnInfoLst = new List<NextStnInfo>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="prmRetsu"></param>
        /// <param name="prmGyou"></param>
        internal SevenOrient(int prmRetsu,int prmGyou)
        {
            OkitaiStn = new Stone(prmRetsu, prmGyou);
            // 置きたい石の隣り合う座標を確定させる。
            SetNxtToStn();
        }

        /// <summary>
        /// 置きたい石の隣り合う座標を取得し、それぞれのリストに格納する。
        /// </summary>
        private void SetNxtToStn()
        {
            //北をセット
            NextStnInfo wkNthStnl = new NextStnInfo(0,- 1,OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkNthStnl);
            //北東をセット
            NextStnInfo wkNthEstStnl = new NextStnInfo(1, -1, OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkNthEstStnl);
            //東をセット
            NextStnInfo wkEstStnl = new NextStnInfo(1, 0, OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkEstStnl);
            //南東をセット
            NextStnInfo wkSthEstStnl = new NextStnInfo(1, 1, OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkSthEstStnl);
            //南をセット
            NextStnInfo wkSthStnl = new NextStnInfo(0, 1, OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkSthStnl);
            //南西をセット
            NextStnInfo wkSthWstStnl = new NextStnInfo(-1, 1, OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkSthWstStnl);
            //西をセット
            NextStnInfo wkWstStnl = new NextStnInfo(-1, 0, OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkWstStnl);
            //北西をセット
            NextStnInfo wkNthWstStnl = new NextStnInfo(-1, -1, OkitaiStn.Retsu, OkitaiStn.Gyou);
            NextStnInfoLst.Add(wkNthWstStnl);

        }
    }
}
