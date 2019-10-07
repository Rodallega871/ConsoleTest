using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTest;
using System.Threading;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //初期画面を表示する。
            bool StartHantei = true;
            GamenOutPut.G01_SelectStart();

            //初期画面からユーザーがEnterを押すまで処理をループする。
            while (true)
            {
                var str = Console.ReadKey(true);
                //上キー下キーを入力する。
                if (str.Key.ToString().Equals(Comm.DownKey)
                    || str.Key.ToString().Equals(Comm.UpKey))
                {
                    if (StartHantei)
                    {
                        GamenOutPut.G01_SelectEnd();
                        StartHantei = false;
                    }
                    else
                    {
                        GamenOutPut.G01_SelectStart();
                        StartHantei = true;
                    }
                }
                //Enterキー入力でwhile文抜ける
                else if (str.Key.ToString().Equals(Comm.EnterKey))
                {
                    break;
                }
            }

            //初期画面で「開始したい」に「⇒」を当てEnterを押下したとき。
            if (StartHantei)
            {
                Console.Clear();
                Console.WriteLine(OutputCharacter.G03_StartUp);
                Thread.Sleep(1500);

                //オセロを開始する。
                String[,] prmGoishiInfo = new String[8, 8];
                //ターンフラグをセットする。()
                bool TrunFlag = true;
                //黒色がCPUであった場合
                bool BlkCPUFlag = false;
                //白色がCPUであった場合
                bool WhtCPUFlag = false;
                //連続パスフラグ
                int PassCount = 0;

                //オセロ画面の初期配置を画面出力する。
                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);

                //画面インデックス
                int G03_index = 0;


                //対戦選択画面からユーザーがEnterを押すまで処理をループする。
                while (true)
                {
                    GamenOutPut.OutputG03(G03_index);
                    var strSelctKey = Console.ReadKey(true);
                    //上キーを入力する。
                    if (strSelctKey.Key.ToString().Equals(Comm.UpKey))
                    {
                        G03_index++;
                    }
                    //下キー入力
                    else if (strSelctKey.Key.ToString().Equals(Comm.DownKey))
                    {
                        G03_index--;
                    }
                    //Enterキー入力でwhile文抜ける
                    else if (strSelctKey.Key.ToString().Equals(Comm.EnterKey))
                    {
                        //対戦形式をセットする。
                        if (G03_index % 3 == 1 || G03_index % 3 == -2)
                        {
                            //黒をCPUに設定する。
                            BlkCPUFlag = true;
                        }
                        else if (G03_index % 3 == 2 || G03_index % 3 == -1)
                        {
                            //白をCPUに設定する。
                            WhtCPUFlag = true;
                        }
                        break;
                    }

                    if (G03_index == 99 || G03_index == -99)
                    {
                        //intのサイズが大きすぎると初期化する。
                        G03_index = 0;
                    }

                }

                //初期の碁石を配置する。
                for (int i = 0; prmGoishiInfo.GetLength(0) > i; i++)
                {
                    for (int j = 0; prmGoishiInfo.GetLength(1) > j; j++)
                    {
                        if ((i == 3 && j == 3) || (i == 4 && j == 4))
                        {
                            //初期黒碁石を配置
                            prmGoishiInfo[i, j] = OutputCharacter.G01_Ban_BlackGoihsi;
                        }
                        else if ((i == 3 && j == 4) || (i == 4 && j == 3))
                        {
                            //初期白碁石を配置
                            prmGoishiInfo[i, j] = OutputCharacter.G01_Ban_WhiteGoihsi;
                        }
                        else
                        {
                            //その他碁石を配置
                            prmGoishiInfo[i, j] = OutputCharacter.G01_Ban_NoGoihsi;
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine(OutputCharacter.G02_StartUp);
                Thread.Sleep(1500);

                //オセロ画面の初期配置を画面出力する。
                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);

                while (true)
                {
                    //入力値を保持する
                    String input = "";

                    /**
                     * CPU判定ロジック
                     * CPU白とCPU黒のみキー待ちをしない。
                     * 自動的に更新する。
                     **/
                    if ((WhtCPUFlag && !TrunFlag) || (BlkCPUFlag && TrunFlag))
                    {
                        /**
                         * CPUロジック
                         **/
                        //臨場感を出すため1秒待機する。
                        Thread.Sleep(1000);

                        //CPUロジッククラス生成する。
                        CPUAlgo algo= new CPUAlgo(prmGoishiInfo, TrunFlag);
                        //CPUInfoListのサイズを確認する。
                        if (algo.CPUInfoList.Count == 0)
                        {
                            //場所がないのでパスする。
                            if (TrunFlag)
                            {
                                TrunFlag = false;
                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                            }
                            else
                            {
                                TrunFlag = true;
                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                            }
                            GamenOutPut.G02_OseroGamen_Pass();
                            PassCount++;
                        }
                        else
                        {
                            //一つ以上置ける場所がある場合は以下メソッドで場所を決定する。
                            algo.DecideMaxCountPlace();

                            if (TrunFlag)
                            {
                                prmGoishiInfo[algo.KakuteiStn.sevenOrient.OkitaiStn.Retsu,
                                              algo.KakuteiStn.sevenOrient.OkitaiStn.Gyou] 
                                              = OutputCharacter.G01_Ban_BlackGoihsi;

                                //石を更新する
                                prmGoishiInfo = algo.KakuteiStn.UpdateStn(TrunFlag);
                                //黒のターンの場合黒碁石をセットし画面出力する。
                                TrunFlag = false;
                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                            }
                            else
                            {
                                prmGoishiInfo[algo.KakuteiStn.sevenOrient.OkitaiStn.Retsu,
                                              algo.KakuteiStn.sevenOrient.OkitaiStn.Gyou]
                                              = OutputCharacter.G01_Ban_WhiteGoihsi;
                                //石を更新する
                                prmGoishiInfo = algo.KakuteiStn.UpdateStn(TrunFlag);
                                //白のターンの場合白碁石をセットし画面出力する。
                                TrunFlag = true;
                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                            }
                            //パスカウントをクリアにする。
                            PassCount = 0;
                        }
                    }
                    else
                    {
                        input = Console.ReadLine();

                        //パスが入力されたとき
                        if (input.Equals(Comm.PassEnter))
                        {
                            if (TrunFlag)
                            {
                                TrunFlag = false;
                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                            }
                            else
                            {
                                TrunFlag = true;
                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                            }
                            GamenOutPut.G02_OseroGamen_Pass();
                            PassCount++;
                        }
                        //pass以外が入力されたとき
                        else
                        {
                            //入力値チェックを実施する(入力文字数が2であること)。
                            if (input.Length != 2)
                            {
                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                //警告を出力する。
                                Console.WriteLine(OutputCharacter.G01_alert01);
                            }
                            else
                            {
                                int tryPreseYou;
                                //入力値チェックを実施する(1文字目が文字であること)。
                                var wkRetus = input.Substring(0, 1);
                                if (int.TryParse(wkRetus, out tryPreseYou))
                                {
                                    GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                    //警告を出力する。
                                    Console.WriteLine(OutputCharacter.G01_alert02);
                                }
                                else
                                {
                                    //入力値チェックを実施する(2文字目が数字であること)。
                                    var wkGyou = input.Substring(1, 1);
                                    if (!int.TryParse(wkGyou, out tryPreseYou))
                                    {
                                        GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                        //警告を出力する。
                                        Console.WriteLine(OutputCharacter.G01_alert03);
                                    }
                                    else
                                    {
                                        //入力値チェックを実施する(指定された配列が0から7の間(盤の中)である。)
                                        var Retus = Comm.ToInt(wkRetus);
                                        var Gyou = int.Parse(wkGyou);
                                        if (Comm.ChkInnerOseroBan(Retus, Gyou))
                                        {
                                            /*
                                             * オセロロジック開始
                                             */

                                            ChkCanPutStn chkCan = new ChkCanPutStn(Retus, Gyou, prmGoishiInfo);
                                            if (!chkCan.ChkOkitaiPlace())
                                            {
                                                GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                                //警告を出力する。
                                                Console.WriteLine(OutputCharacter.G01_alert05);
                                            }
                                            else
                                            {
                                                if (chkCan.ChkNextPlace(TrunFlag))
                                                {
                                                    if (chkCan.ChkNextPlaceRoop(TrunFlag))
                                                    {
                                                        prmGoishiInfo = chkCan.UpdateStn(TrunFlag);
                                                        if (TrunFlag)
                                                        {
                                                            //黒のターンの場合黒碁石をセットし画面出力する。
                                                            prmGoishiInfo[Retus, Gyou] = OutputCharacter.G01_Ban_BlackGoihsi;
                                                            TrunFlag = false;
                                                            GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                                        }
                                                        else
                                                        {
                                                            //白のターンの場合白碁石をセットし画面出力する。
                                                            prmGoishiInfo[Retus, Gyou] = OutputCharacter.G01_Ban_WhiteGoihsi;
                                                            TrunFlag = true;
                                                            GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                                        }
                                                        //パスカウントをクリアにする。
                                                        PassCount = 0;
                                                    }
                                                    else
                                                    {
                                                        GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                                        //警告を出力する。
                                                        Console.WriteLine(OutputCharacter.G01_alert05);
                                                    }

                                                }
                                                else
                                                {
                                                    GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                                    //警告を出力する。
                                                    Console.WriteLine(OutputCharacter.G01_alert05);
                                                }
                                            }

                                            /*
                                             * オセロロジック終了
                                             */
                                        }
                                        else
                                        {
                                            //入力された箇所が8×8に収まっていない場合。
                                            GamenOutPut.G02_OseroGamen(prmGoishiInfo, TrunFlag);
                                            //警告を出力する。
                                            Console.WriteLine(OutputCharacter.G01_alert04);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //現在の集計を実施する。
                    int BlackAll = 0;
                    int WhiteAll = 0;
                    int AkiSpaceAll = 0;

                    for (int i = 0; prmGoishiInfo.GetLength(0) > i; i++)
                    {
                        for (int j = 0; prmGoishiInfo.GetLength(1) > j; j++)
                        {
                            if (prmGoishiInfo[i, j].Equals(OutputCharacter.G01_Ban_BlackGoihsi))
                            {
                                //黒をカウントする。
                                BlackAll++;
                            }
                            else if (prmGoishiInfo[i, j].Equals(OutputCharacter.G01_Ban_WhiteGoihsi))
                            {
                                //白をカウントする。
                                WhiteAll++;
                            }
                            else if (prmGoishiInfo[i, j].Equals(OutputCharacter.G01_Ban_NoGoihsi))
                            {
                                //空きスペースをカウントする。
                                AkiSpaceAll++;
                            }
                        }
                    }

                    //パスカウントが2になる及び空きスペースが0になった場合ゲームを強制終了させる。
                    if (AkiSpaceAll == 0 || PassCount == 2)
                    {
                        GamenOutPut.G02_OseroGamen_Result(prmGoishiInfo, BlackAll, WhiteAll, AkiSpaceAll);
                        break;
                    }

                }//while文終了

                Console.ReadKey(true);
                //何かボタンを押すことで画面を閉じる。
                Console.WriteLine(OutputCharacter.G01_alert06);
                Console.ReadKey(true);

            }
            //初期画面で「やめたい」に「⇒」を当てEnterを押下したとき。
            else
            {
                Console.WriteLine(OutputCharacter.G01_End);
                Thread.Sleep(1500);
            }

        }

    }
}
