using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 出力文字をまとめたクラス
    /// </summary>
    class OutputCharacter
    {

        //共通メッセージ
        internal static readonly String RoDaimei = "マイナンバー管理システム";

        //初期画面メッセージ
        internal static readonly String G01_Nm = "ログイン画面";
        internal static readonly String G01_StartGm = "開始したい。";
        internal static readonly String G01_EndGm = "やめたい。";
        internal static readonly String G01_EnterWo = "「⇒」を項目に合わせてEnterを入力してください。";
        internal static readonly String G01_RoSankaku = "⇒";

        //初期画面(やめたいときのメッセージ)
        internal static readonly String G01_End = "マイナンバーアプリを終了します。";

        //オセロ画面(上画面)
        internal static readonly String G02_StartUp = "マイナンバー登録画面を表示します。";


        //オセロ画面(上画面)
        internal static readonly String G02_Nm = "登録画面";
        internal static readonly String G01_Line = "-------------------------------------------------------------";
        internal static readonly String G02_BlackTrunComment = "黒(●)のターンです。";
        internal static readonly String G02_WhiteTrunComment = "白(〇)のターンです。";
        //オセロ画面(盤の座標)
        internal static readonly String G01_Ban_Retsu = "  |a b c d e f g h";
        internal static readonly String G01_Ban_Gyou_Sep = "-------------------";
        internal static readonly String G01_Ban_Retsu_Sep = " |";


        //オセロ画面(駒描写)
        internal static readonly String G01_Ban_NoGoihsi = "・";
        internal static readonly String G01_Ban_BlackGoihsi = "●";
        internal static readonly String G01_Ban_WhiteGoihsi = "○";

        //オセロ画面(下画面)
        internal static readonly String G01_Ban_Messeage = "下に置きたい場所に列名行名の順に(例：「a1」)を指定しEnterを押してください。"
            + Environment.NewLine + "盤に石が置けないやパスしたいときは「pass」と入力してください。" ;
        internal static readonly String G01_Ban_Messeage_pass = "相手がパスしました。";

        //オセロ画面(警告)
        internal static readonly String G01_alert01 = "2文字で入力してください";
        internal static readonly String G01_alert02 = "1文字目は文字で入力してください";
        internal static readonly String G01_alert03 = "2文字目は数字で入力してください";
        internal static readonly String G01_alert04 = "1文字目はa～hで入力し、2文字目は0～7で入力してください";
        internal static readonly String G01_alert05 = "そこには置けません";
        internal static readonly String G01_alert06 = "次ボタンを押下するとアプリを終了します。";

        //オセロ画面(結果)
        internal static readonly String G02_Result_Bwin = "黒(●)の勝利";
        internal static readonly String G02_Result_Wwin = "白(〇)の勝利";
        internal static readonly String G02_Result_Draw = "引き分けです。";

        //オセロ画面(上画面)
        internal static readonly String G03_StartUp = "処理対象データ画面(マイナンバー)を表示します。";
        
        //対戦形式選択画面　上画面
        internal static readonly String G03_Nm = "処理対象データ入力画面";
        //対戦形式選択画面　選択時出力　
        internal static readonly String G03_Select_freeVS = "Player1 VS Player2";
        internal static readonly String G03_Select_VSWhiteCPU = "Player VS CPU (Player先行)";
        internal static readonly String G03_Select_VSBlackCPU = "Player VS CPU (Player後攻)";
        //対戦形式選択インデックス
        enum VS_index { freeVS, VSWhiteCPU, VSBlackCPU };




    }
}
