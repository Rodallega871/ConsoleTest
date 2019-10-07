using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 画面出力処理をまとめたクラス
    /// </summary>
    class GamenOutPut
    {

        /// <summary>
        /// 初期画面で「開始したい」に⇒を当てた時に出力
        /// </summary>
        internal static void G01_SelectStart()
        {
            Console.Clear();           
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G01_Nm);
            Console.Write(OutputCharacter.G01_RoSankaku);
            Console.Write(" ");
            Console.WriteLine(OutputCharacter.G01_StartGm);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G01_EndGm);
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_EnterWo);            
        }

        /// <summary>
        /// 初期画面で「やめたい」にに⇒を当てた時に出力
        /// </summary>
        internal static void G01_SelectEnd()
        {
            Console.Clear();
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G01_Nm);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G01_StartGm);
            Console.Write(OutputCharacter.G01_RoSankaku);
            Console.Write(" ");
            Console.WriteLine(OutputCharacter.G01_EndGm);
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_EnterWo);
        }

        /// <summary>
        /// オセロ画面の画面説明及び列までを表示する。
        /// </summary>
        internal static void G02_BlackTern()
        {
            Console.Clear();
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G02_Nm);
            Console.WriteLine(OutputCharacter.G02_BlackTrunComment);

            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_Line);

            Console.WriteLine(OutputCharacter.G01_Ban_Retsu);
            Console.WriteLine(OutputCharacter.G01_Ban_Gyou_Sep);
        }

        /// <summary>
        /// オセロ画面の画面説明及び列までを表示する。
        /// </summary>
        internal static void G02_WhiteTern()
        {
            Console.Clear();
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G02_Nm);
            Console.WriteLine(OutputCharacter.G02_WhiteTrunComment);
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_Line);

            Console.WriteLine(OutputCharacter.G01_Ban_Retsu);
            Console.WriteLine(OutputCharacter.G01_Ban_Gyou_Sep);
        }


        /// <summary>
        /// オセロ画面を表示する(黒のターン)。
        /// </summary>
        internal static void G02_OseroGamen(String[,] prmGoishiInfo,bool prmTrunFlag)
        {
            //白のターンか黒のターンかを判別し値を変更する。
            if (prmTrunFlag)
            {
                G02_BlackTern();
            }
            else
            {
                G02_WhiteTern();
            }

            for (int i = 0; prmGoishiInfo.GetLength(0) > i; i++)
            {
                Console.Write(i);
                Console.Write(OutputCharacter.G01_Ban_Retsu_Sep);
                for (int j = 0; prmGoishiInfo.GetLength(1) > j; j++)
                {
                    Console.Write(prmGoishiInfo[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_Ban_Messeage);

        }

        /// <summary>
        /// オセロ画面でパスを入力された場合出力する文言。
        /// </summary>
        internal static void G02_OseroGamen_Pass()
        {
            Console.WriteLine(OutputCharacter.G01_Ban_Messeage_pass);
        }

        /// <summary>
        /// オセロ画面で結果を画面に出力する。
        /// </summary>
        internal static void G02_OseroGamen_Result(String[,] prmGoishiInfo,int countB,int countW,int countSp)
        {

            Console.Clear();
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G02_Nm);
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_Line);
            Console.WriteLine(OutputCharacter.G01_Ban_Retsu);
            Console.WriteLine(OutputCharacter.G01_Ban_Gyou_Sep);

            for (int i = 0; prmGoishiInfo.GetLength(0) > i; i++)
            {
                Console.Write(i);
                Console.Write(OutputCharacter.G01_Ban_Retsu_Sep);
                for (int j = 0; prmGoishiInfo.GetLength(1) > j; j++)
                {
                    Console.Write(prmGoishiInfo[j, i]);
                }
                Console.WriteLine();
            }

            if (countB == countW)
            {
                //引き分け
                Console.WriteLine(OutputCharacter.G02_Result_Draw);
            }
            else if (countB > countW)
            {
                //黒
                Console.WriteLine(OutputCharacter.G02_Result_Bwin);
            }
            else if (countB < countW)
            {
                //白
                Console.WriteLine(OutputCharacter.G02_Result_Wwin);
            }
            Console.WriteLine("黒(●)　　：" + countB);
            Console.WriteLine("白(〇)　　：" + countW);
            Console.WriteLine("空き(・)　：" + countSp);
        }


        /// <summary>
        /// 対戦形式選択画面(フリー対戦)
        /// </summary>
        internal static void G03_SelectfreeVS()
        {
            Console.Clear();
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G03_Nm);
            Console.Write(OutputCharacter.G01_RoSankaku);
            Console.Write(" ");
            Console.WriteLine(OutputCharacter.G03_Select_freeVS);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G03_Select_VSWhiteCPU);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G03_Select_VSBlackCPU);
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_EnterWo);
        }

        /// <summary>
        /// 対戦形式選択画面(フリー対戦)
        /// </summary>
        internal static void G03_SelectVSWhiteCPU()
        {
            Console.Clear();
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G03_Nm);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G03_Select_freeVS);
            Console.Write(OutputCharacter.G01_RoSankaku);
            Console.Write(" ");
            Console.WriteLine(OutputCharacter.G03_Select_VSWhiteCPU);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G03_Select_VSBlackCPU);
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_EnterWo);
        }

        /// <summary>
        /// 対戦形式選択画面(フリー対戦)
        /// </summary>
        internal static void G03_SelectVSBlackCPU()
        {
            Console.Clear();
            Console.WriteLine(OutputCharacter.RoDaimei);
            Console.WriteLine(OutputCharacter.G03_Nm);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G03_Select_freeVS);
            Console.Write("   ");
            Console.WriteLine(OutputCharacter.G03_Select_VSWhiteCPU);
            Console.Write(OutputCharacter.G01_RoSankaku);
            Console.Write(" ");
            Console.WriteLine(OutputCharacter.G03_Select_VSBlackCPU);
            Console.WriteLine();
            Console.WriteLine(OutputCharacter.G01_EnterWo);
        }

        /// <summary>
        /// 対戦形式選択画面
        /// 対象のindexとマッチする画面を出力する。
        /// </summary>
        /// <param name="prmIndex"></param>
        internal static void OutputG03(int prmIndex)
        {
            if (prmIndex % 3 == 0)
            {
                GamenOutPut.G03_SelectfreeVS();
            }
            else if (prmIndex % 3 == 1 || prmIndex % 3 == -2)
            {
                GamenOutPut.G03_SelectVSBlackCPU();
            }
            else if (prmIndex % 3 == 2 || prmIndex % 3 == -1)
            {
                GamenOutPut.G03_SelectVSWhiteCPU();
            }
        }
    }
}
