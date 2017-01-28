using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSite.Controllers
{
    using Models;

    [Route("gallery/")]
    public class GalleryController : Controller
    {
        [Route("{article}/")]
        public IActionResult List(string article)
        {
            switch (article)
            {
                case "170128experiment":
                    var fileLinks = System.IO.Directory.EnumerateFiles("./wwwroot/gallery/170128experiment")
                        .Select(filePath =>
                            new LinkInfo() {
                                Title = System.IO.Path.GetFileName(filePath),
                                Action = Url.Content("~" + filePath.Substring("./wwwroot".Length))
                            })
                        .ToArray();
                    var contents = new GalleryInfo<LinkInfo>()
                    {
                        Id = "170128experiment",
                        Title = "実験場",
                        Summary = "色々試す場所",
                        Description = "(´・ω・`)...",
                        Groups = new[]
                        {
                            new GroupInfo<LinkInfo>()
                            {
                                Children = fileLinks
                            }
                        }
                    };
                    return View("List2", contents);
                default:
                    GalleryInfo<WorkInfo> obj;
                    if (bbb.TryGetValue(article, out obj) == false)
                        return NotFound();
                    return View(obj);
            }

        }
        [Route("{article}/{id}")]
        public IActionResult Detail(string article, int id)
        {
            GalleryInfo<WorkInfo> obj;
            if (bbb.TryGetValue(article, out obj) == false)
                return NotFound();

            var totalWrkLen = obj.Groups.Sum(_ => _.Children.Length);
            if (id < 0 || id >= totalWrkLen)
                return NotFound();

            var wrkIdx = id;
            var grpIdx = 0;
            for (var i = 0; wrkIdx >= obj.Groups[i].Children.Length; i++)
            {
                wrkIdx -= obj.Groups[i].Children.Length;
                grpIdx++;
            }

            ViewBag.HasPreviousItem = id > 0;
            ViewBag.HasNextItem = id < totalWrkLen - 1;
            ViewBag.PrevIndex = id - 1;
            ViewBag.NextIndex = id + 1;
            ViewBag.CurrentArticle = article;
            return View(obj.Groups[grpIdx].Children[wrkIdx]);
        }
        #region Data
        Dictionary<string, GalleryInfo<WorkInfo>> bbb = new Dictionary<string, GalleryInfo<WorkInfo>>()
        {
            {
                "100720infoExpr",
                new GalleryInfo<WorkInfo>()
                {
                    Id = "100720infoExpr",
                    Title = "大学演習科目課題",
                    Summary = "授業の課題で作成した成果物を陳列しています。",
                    Description = "色々、授業の課題で作ったものや、作る過程で破棄されたもの等を陳列してます。",
                    Groups = new[]
                    {
                        new GroupInfo<WorkInfo>()
                        {
                            Children = new[]
                            {
                                new WorkInfo()
                                {
                                    Id = "k05th_animalplant",
                                    Title = "第4-5回: plants animal",
                                    Summary = "Photoshopを使用し、素材から似たな部分を見つけて架空の生物を作成しました。",
                                    Content = "<img class='picture' src='k05th_animalplant/anmlPlnt.jpg' alt='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "素材集の中から、植物と動物の形態・テクスチャーをよく観察し、お互いの相似な部分を見つけて、ひとつの新たな架空の生物として合成しなさい。あくまで植物と動物の色や形、テクスチャーなどの「似たところ」をうまく見立てて、両者を結びつけて自然に見えるように合成してください。合成に使用する素材は、植物1種類、動物1種類の2つとします。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "キャベツの葉の重なり具合がダチョウのモサモサに似ているように思えたため、合成しました。当初は、これは練習目的だったのですが、本命のトウモロコシと動物の皮膚の合成が出来の悪い模型の珍獣になってしまい、これを本番としました。合成において、艶のある物体の扱いが難しいというのは意外でした。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "k06th_flashmotion",
                                    Title = "第6回: Flashアニメーション",
                                    Summary = "モーションガイドを利用したアニメーションを作成。蛇口から水滴が垂れる状況をFlashで表現しました。",
                                    Content = "<embed class='picture' src='k06th_flashmotion/k6th.swf' width='320' height='228' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed>",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "任意にテーマを選んでモーションガイドを利用したアニメーションを作成すること。具体的なモチーフを選び、それに相応しい自然な動きのアニメーションを作成してほしい。なお、ボタンを1つ作り、クリックするたびにアニメーションが見られるようにすること。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "モーショントゥーインの動きに魅せられて作りました。個人的には一番良く出来たかと思っています。課題自体はモーションガイドを使わなければならない課題であったため、どのようにモーションガイドが必要になる動きを組み込むかにとても悩みました。結果的に最後の水滴が小さい物体に衝突し、飛び散る動きで使用しましたが、そんなものはどうでもいいです。蛇口から水滴が出来、蛇口から離れるまでが全てです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "k07th_flashas",
                                    Title = "第7回: Flash動的表現",
                                    Summary = "ActionScriptを用いたインタラクティブな表現。スイッチの状態に合わせてコンビニおにぎりを切り替えるFlashを作成しました。",
                                    Content = "<embed class='picture' src='k07th_flashas/k07th.swf' width='320' height='245' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed>",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "インタラクティブなFlashコンテンツを作成する。同じ場面で4つの異なる情況を各自で考えて撮影し、ON/OFFスイッチに合わせて4通りの画像が切り替わるようにすること。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "当初思いついたのは、頭皮が荒野となっている人の頭上を光らせるスイッチだったのですが、著作権やら名誉が云々で面倒だと思ったために色々考えた末、コンビニのおにぎりになりました。見どころは本来、剥がしたら戻せないはずの表面の包装がスイッチを切るだけで戻せる点です。現実じゃこうはいきません。普段趣味で使う開発環境はVisualStudioなのでFlashの開発環境のActionScriptの編集機能の貧弱さに戸惑いました。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "k08th_html",
                                    Title = "第8回: HTMLのマークアップ",
                                    Summary = "関心のあるテーマでWeb ページを作成しました。",
                                    Content = "<a href='k08th_html/contents/k08th.html' class='picture'><img class='picture' src='k08th_html/contentsSS.jpg' alt='picture' /></a>",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "自分が興味・関心のある題材を用いて 、Web ページ（1ページだけでよい）を作成してください。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "課題が課された当時に着手していたデジタルデータ基礎のレポート課題の書きかけの形式が見出しやテーブル等で今回の課題で使う必要のあるタグに一致していたため、コピーせずして何がデジタルデータだと思いながら再利用しました。Wordの表をTableタグに移すのが大変でした。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "k09th_htmlcss1",
                                    Title = "第9回: CSSを加えたもの",
                                    Summary = "CSSを用いてウェブページのh1タグ等に装飾を施しました。",
                                    Content = "<a href='k09th_htmlcss1/contents/k09th.html' class='picture'><img class='picture' src='k09th_htmlcss1/contentsSS.jpg' alt='picture' /></a>",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "第8回目の課題の生成物を基にCSSを用いて Web ページに独自のスタイルを設定してください。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "授業で扱ったサンプル教材のCSSを参考にそのままやりました。特に感想は無い。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "k10th_htmlcss2",
                                    Title = "第10回: CSSページレイアウト",
                                    Summary = "第9回のCSSの学習をさらに進め、divタグを用いたページレイアウトやlistタグの挙動を変えたりしました。",
                                    Content = "<a href='k10th_htmlcss2/contents/kadai_p1.html' class='picture'><img class='picture' src='k10th_htmlcss2/contentsSS.jpg' alt='picture' /></a>",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "第9回目の課題で作成した Web ページにレイアウトを設定してください。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "IEのレンダリングエンジンのバグやCSSの珍仕様に度々遭遇し、ひどく疲弊しました。早くIEがインターネットから消えて欲しいと思うのは勿論、CSSの癖のある動きへもうんざりさせられました。仕様が統一されている面でFlashが素晴らしく思えました。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "k11th_link",
                                    Title = "第11回: リンク集",
                                    Summary = "これまでのHTML&CSSの知識を総動員し、お勧めのサイトを集めたリンク集を作りました。",
                                    Content = "<a href='k11th_link/contents/links.html' class='picture'><img class='picture' src='k11th_link/contentsSS.jpg' alt='picture' /></a>",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "あなたが是非みんなに教えてあげたいと思うお勧めのサイトを集めたリンク集を作って下さい。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "今回のウェブページを作る課題でも使えるCSSを書こうと思い、意気込んでデザインを作りました。意識した点としては使いまわしが効くようにclass設定を用いて各デザインの要素を性質ごとに分割しました。だいぶレンダリングエンジンのバグやCSSの珍仕様にも慣れたためにCSSに悩む事はだいぶ減りました。紹介しているサイトは自分のはてなブックマークから探しましたが、動画リンクサイト等が多かったために真面目なサイトを探すのに苦労しました。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "k12th_web",
                                    Title = "第12回:演習課題掲載サイト",
                                    Summary = "これまで授業で学んだの知識を総動員し、ウェブサイトを構築しました。",
                                    Content = "<a href='k12th_web/contents/index.html' class='picture'><img class='picture' src='k12th_web/contentsSS.jpg' alt='picture' /></a>",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "課題文",
                                            Content = "これまでの演習課題を掲載したWebページを作成する。なお、ページデザインはほぼ自由で各自の好みである。"
                                        },
                                        new CardInfo()
                                        {
                                            Title = "感想",
                                            Content = "当サイトの初期ver1.0です。ver1.0まで掲載しろとは言われてませんが折角なので載せました。ただ、画像等が現バージョンと共有なので一部おかしいです。CSSが第11回の演習課題で作成したものを継承したために似ています。認識している問題点として、パンくずリストは途中で付け加えたために少々分かりずらいものとなってしまっています。そのため、現バージョンでは改善しました。また、この頃からCSSのLayoutとColorを別ファイルとして分離するようになったために容易にColorを全面変更する事が出来るようになりました。現バージョンでは汎用性の高い外見のLayoutとColorに1つ用意し、ページ共通のLayoutとColorに2つ。個別のページのLayoutとColorで2つに分けています。ちなみに夏季休暇課題で作成したver2.0は当然ver1.0のCSSを改良するはずで、休暇前にベースの大部分が既に出来ていたのですが、タギング方法を文章構造重視にした為に大部分が書きなおす事となり、現verは3.0とも言えます。"
                                        }
                                    }
                                },
                            }
                        }
                    }
                }
            },
            {
                "100823takao",
                new GalleryInfo<WorkInfo>()
                {
                    Id = "100823takao",
                    Title = "夏季休暇課題",
                    Summary = "高尾山の夏の動植物諸々、見つけた物を片っ端から撮って調べてみました。",
                    Description = "高尾山は標高が低く都心からとても近い山ですが、とても動植物が多い山として知られています。今回は川が近くに流れる6号路を通りました。そのため、湿った場所に生える植物が沢山撮られています。また、ついでに写真のサイズについてですが、古いコンデジであるために低解像度&低感度&高ノイズ&手ブレ補正無しで、散々な写りとなってしまいました。そのため、縮小して誤魔化しています。ご容赦を。",
                    Groups = new[]
                    {
                        new GroupInfo<WorkInfo>()
                        {
                            Title = "草",
                            Children = new[]
                            {
                                new WorkInfo()
                                {
                                    Id = "dikn",
                                    Title = "ダイコンソウ",
                                    Summary = "バラ科ダイコンソウ属",
                                    Content = "<img src='dikn/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "登山の始めの方の沢に近づく道あたりでシダやらシャガに混じって見つけました。この植物は多年草で、耐寒性で冬は地上部を枯らす宿根性だそうです。各地の渓谷付近等のやや湿った場所に生え、7月～8月あたりに花を咲かせます。葉の形状が大根の葉に似ている事からこの名が名づけられて様ですが、大根がアブラナ科である一方、ダイコンソウはバラ科のため全く縁が無い感じです。また、自生種としてダイコンソウ属内でチングルマ等の同属が存在しますがダイコンソウ以外は高山に生える植物で、園芸種ではゲウムが同属です。花の先端にはフックの様な柱頭があり、服に引っかかる感じです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "gezi",
                                    Title = "ゲジゲジシダ",
                                    Summary = "ヒメシダ科ヒメシダ属",
                                    Content = "<img src='gezi/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "琵琶滝までの道に沢山生えていました。この植物はゲジゲジみたいな葉の生え方からそう呼ばれているそうです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "hana",
                                    Title = "ハナイカダ",
                                    Summary = "ミズキ科ハナイカダ属",
                                    Content = "<img src='hana/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "琵琶滝付近の沢に平行した道で見つけました。この植物は落葉性で低木で、5月～6月あたりに花を咲かせるそうです。特徴的な点として葉の中央に花を咲かせる点が挙げられ、8月時点では実になっていましたが見つけた時のインパクトは実でも十分でした(始めは別の植物が貫通しているのかと思いました)。名前の由来も葉をイカダに見立てたものだそうです。また、オスとメスの株があり、小学生時に育てたヘチマ以上に面倒な植物に思えます。写真撮影時には既に実の段階であったためにオスを見る事が出来ませんでしたが、メスの花は葉の上に通常1個出来るのに対し、オスの花は数個出来る様です。実は甘みがあり、食べられるそうです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "hebi",
                                    Title = "ヘビイチゴ",
                                    Summary = "バラ科ヘビイチゴ属",
                                    Content = "<img src='hebi/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "シダ&シャガに混じってましたが、野原や水田に生える多年草だそうです。これは自宅近くの小さい山でも見かけたりしますが、この植物は4月～6月あたりに黄色い5枚の花弁を持った花が咲くそうです。また、今まで有毒植物と思ってましたが違うようです。しかし、味が無く、不味いらしいです。また、名前の由来として蛇が食べるイチゴや蛇が獲物を狙うための餌代わり等言われているようですが良く分かりません。同属としてヤブヘビイチゴという種類があり、こちらはヘビイチゴよりも生える地域が限られており、実が赤く、光沢があり、林の縁等の光が少ない場所に生え、葉も色が濃いという違いがあるようですが、写真のがどっちかは分かりませんでした。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "inod",
                                    Title = "イノデ",
                                    Summary = "オシダ科イノデ属",
                                    Content = "<img src='inod/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "ゲジゲジ等のシダに混じってシダの仲間のイノデが生えてました。シダにも種類がありますが、イノデ内でも複数の種類があり、シダ植物門オシダ科イノデ属と言う形でまとめられているのですが、その種類の中で雑種がどんどん出来るため、色々あるようです。ちなみに、そのどれに写真が属しているのかは良く分かりませんでした。名前の由来は新芽がイノシシの足のように毛むくじゃらな様子からそのように名付けられたようですが、確かに毛むくじゃらのようです(<a href=\"http://www.google.co.jp/images?q=%E3%82%A4%E3%83%8E%E3%83%87+%E6%96%B0%E8%8A%BD\" target=\"_blank\">Google</a>)。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "ktne",
                                    Title = "ヤマキツネノボタン",
                                    Summary = "キンポウゲ科キンポウゲ属",
                                    Content = "<img src='ktne/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "これも琵琶滝までの道でシダの類に混じって生えており、ヤマキツネノボタンと言うそうです。日本各地に生えており、水田周辺の水路や溝、畦など、湿り気のある場所に生え、5月から7月あたりに花を咲かせる多年生の草本だそうです。花はかなり黄色いです。また、咲いた後に中央に出来る実は、複数の実が集合して出来ており、一つ一つの実には鍵状の突起が付いているために服に引っかかります。この果実の形状から、別名ではコンペイトウグサとも言うそうです。また、ヤマが抜けたキツネノボタンという種類もあり、ヤマの方が毛が多いそうです。違いが良く分かりませんが頂上のビジターセンターで紹介されていたのがヤマの方でしたし、山に生えていたので多分写真のはヤマの方なんでしょう。ちなみにトリカブト等、キンポウゲ科の植物には毒を持つものが多く、キツネノボタンも有毒植物だそうです。そのため、植物の汁に触れるとかぶれ、食べると消化器が炎症を起こします。よって、服に付いた実を包装材のプチプチみたく潰して遊ばないようにしましょう。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "mizk",
                                    Title = "ミズヒキ",
                                    Summary = "タデ科ミズヒキ属",
                                    Content = "<img src='mizk/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "この植物は写真は撮ったのですが発見場所を忘れました。たぶんシャガ付近でしょう。写真に写ってますし。この植物は山の林縁や路傍に生える多年草で、8月～10月あたりに花を咲かせるそうです。花弁が無く、写真の赤く見えるのは\"がく\"だそうです。そして時期によって葉が八のような模様が付く様です。写真から分かるように、高さが30cm～80cmの茎に花が直接出てきています。また、種が服などにくっ付いて運ばれます。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "myic",
                                    Title = "ミヤマフユイチゴ",
                                    Summary = "バラ科キイチゴ属",
                                    Content = "<img src='myic/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "登り始めのシダの生えてる辺りで見つけました。この植物は山や川岸に生える常緑樹で、つる性の茎は地面を這い、棘を持つそうです。深山と書いてミヤマと読みますが、高尾山という低山に生えてしまう浅山苺です。9月～10月にかけて白い花を咲かせ、１１月～１月あたりに赤い果実が実り、食べられるそうです。同属としてフユイチゴという似た種が有りますが、こちらは棘が無く、葉はミヤマフユイチゴよりも先端が丸くなっているそうですが、他は殆ど一緒どころか雑種まで出来てしまうために区別が難しかったりするようです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "shga",
                                    Title = "シャガ",
                                    Summary = "アヤメ科アヤメ属",
                                    Content = "<img src='shga/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "登山中盤までよく見かけた気がします。この植物はやや湿った場所に生える常緑性の多年草で、4月～5月あたりに花を咲かせるそうです。細長い光沢のある葉がいたる所で群生しており、山の斜面を支える事が役割があるそうです。8月に来たので当然花は有りませんでしたが、花は1日で萎んでしまい、種子は作らないそうです。この植物はどうやら中国から持ち込まれたものが野生化したものらしいです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "tama",
                                    Title = "タマアジサイ",
                                    Summary = "アジサイ科アジサイ属",
                                    Content = "<img src='tama/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "数は多くないですが、山の上から下まで何処にでも生えてました。この植物は中部から関東までと福島県、岐阜県あたりに生えており、湿った場所に生える木で、7月～9月あたりに花を咲かせるそうです。良く知られている紫陽花は6月から7月あたりに花が咲くため、タマアジサイはかなり遅咲きと言えます。蕾の形が球体となっており、これが名前の由来となっています。また、写真からも分かりますが、一斉に花が咲く訳ではなく、順次球体が破れたように開いていきます。その為に余計に花を長期間見る事が出来るのと同時に、見た目が木全体で見た時にダサいです。知らなかったのですが、アジサイは当種も普通のも同様に有毒らしいです。カッコつけてカクテルに添えない様にしましょう。確か梅も同様の成分を含むので焼酎に漬ければ食えるかもしれません。"
                                        }
                                    }
                                }
                            }
                        },
                        new GroupInfo<WorkInfo>()
                        {
                            Title = "木",
                            Children = new[]
                            {
                                new WorkInfo()
                                {
                                    Id = "hono",
                                    Title = "ホオノキ",
                                    Summary = "モクレン科モクレン属",
                                    Content = "<img src='hono/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "琵琶滝までより前の道に生えていました。この木は落葉広葉樹で山地の河川等の土壌の厚い場所に生えている木で、5月～6月に花が咲くそうです。また、とても大きな葉を付ける木で、葉は20～40cm程の葉が付き、高尾山の植物の中では最も葉が大きい木です。そして幹が真っすぐに伸び、葉は上の方に付くために近くで葉を撮る事は出来ませんでした。木材としては上質でやわらかいために細工し易く、木細工や家具などに使われ、葉は殺菌作用があり、香りも良いために食べ物を包む際の食器代わりや、朴葉味噌への利用として活用され、樹皮は乾燥されて健胃薬として使われたりするそうです。葉の活用先として朴葉餅が有名だそうですが、これは柏餅に似ています。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "momi",
                                    Title = "モミ",
                                    Summary = "マツ科モミ属",
                                    Content = "<img src='momi/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "撮影場所を忘れましたが、けっこう何処にでも生えてますね。常緑針葉樹で日本の特産種で20m～30mの高さになり、木材は軽くてやわらかく、加工しやすいために建築や器具材、マッチの軸、パルプなどに利用されるそうです。しかし、大気汚染に弱く都市での栽培に向かないそうです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "sdzi",
                                    Title = "スダジイ",
                                    Summary = "ブナ科シイ属",
                                    Content = "<img src='sdzi/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "これも撮影場所忘れました。モミと同じく下山路に生えていました。常緑広葉樹林で葉は厚く深緑色。幹は黒褐色で、成長すると樹皮に縦の切れ目が入るのが特徴らしいです。ちなみに左上を見るとわかりますが、木にスダジイと名前が書いてあったので、この木は間違いなくスダジイです。他のは看板が架かってないので確信が持てなかったりします。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "uraz",
                                    Title = "ウラジロガシ",
                                    Summary = "ブナ科コナラ属",
                                    Content = "<img src='uraz/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "これも撮影場所忘れました。前のと同じく下山路です。樹皮は暗褐色から灰色で滑らか。高さは20cm以上に達します。葉の裏側が白色となっており、これが名前の由来となっています。この手の木の実が\"どんぐり\"と呼ばれるらしいですが、\"どんぐり\"が何者か考えた事が無かったのでへぇ～と思いました。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "kago",
                                    Title = "カゴノキ",
                                    Summary = "クスノキ科カゴノキ属",
                                    Content = "<img src='kago/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "これも撮影場所忘れました。前のと同じく下山路です。常緑樹で樹皮がまばらに剥がれ落ち、鹿の子模様になる点から「鹿子の木(かごのき)」と呼ばれています。8月～9月に花が咲くそうです。また、葉は特徴に欠け、葉のみで種を特定するのは難しいそうです。"
                                        }
                                    }
                                }
                            }
                        },
                        new GroupInfo<WorkInfo>()
                        {
                            Title = "他",
                            Children = new[]
                            {
                                new WorkInfo()
                                {
                                    Id = "neba",
                                    Title = "粘板岩",
                                    Summary = "堆積岩",
                                    Content = "<img src='neba/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "琵琶滝付近で露出していました。堆積岩の一種で、海底の砂や泥が自然の力で押し固められる事によって生成されるそうです。とても硬く、高密度できめ細かい構造をしており、薄く割れやすく風化しにくく、そして磨くと表面がツルツルになります。見る事が出来たのは黒色の粘板岩でしたが、赤や緑、紫色なのもあるそうです。主に瓦や堀、硯、囲碁の黒石などに利用されるそうです。"
                                        }
                                    }
                                },
                                new WorkInfo()
                                {
                                    Id = "zato",
                                    Title = "ザトウムシ",
                                    Summary = "クモ綱ザトウムシ目",
                                    Content = "<img src='zato/image.jpg' class='picture' />",
                                    Descriptions = new[]
                                    {
                                        new CardInfo()
                                        {
                                            Title = "説明",
                                            Content = "琵琶滝以降の道で木の割れ目の間に2匹いました。この虫は中型の蜘蛛の仲間ですが、糸は出さず、頭胸部と腹部の間にくびれが無く、変わっています。この虫は身体が頭胸部と腹部の2つから構成されておらず、全て一個に収まっている点でダニっぽいです。そして、とにかく足が長く、この足の長さを活かして前方をゆさゆさと進んでいくため、気持ち悪いです。主に虫やその死骸を食べるため、頂上のビジターセンターでは森の掃除屋とされていました。視覚は明暗程度しか認識できないためにほぼ盲目といえ、視覚の代わりに周囲の振動を足で感知し、周囲を把握しているようです。まさに座頭虫と言えます。加えて、ザトウムシはピンチの時に足を自切するらしいです。なお、ザトウムシ目の中にも幾つか種類があるようですが写真のがどれに属すかはちょっと分かりませんでした。ちなみに「千と千尋の神隠し」で劇中に登場する「釜爺」のモデルはこれらしいです。釜爺も湯婆婆に絡まれた時に自切すれば湯屋でパシられる契約を結ばずに済んだのかもしれません。"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
        };
        #endregion
    }
}
