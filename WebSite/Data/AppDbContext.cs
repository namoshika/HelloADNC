using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;

namespace WebSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Page> Page { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<ContentCard> ContentCard { get; set; }
        public DbSet<ContentInfoExpr> ContentInfoExpr { get; set; }
        public DbSet<ContentTakao> ContentTakao { get; set; }
        public DbSet<UpdateLog> UpdateHistory { get; set; }
        public DbSet<Pin> RootPin { get; set; }

        public void EnsureSeedData()
        {
            Database.EnsureCreated();
            if (Page.Any() || ContentCard.Any() || Group.Any())
                return;

            Page.AddRange(
                new Page()
                {
                    Id = "root",
                    Title = "Top",
                    Summary = "このサイトでは、{0}が大学演習科目で作成した成果物を陳列しております。特に価値有るものはありませんがゆっくりしていって下さい。",
                    Controller = "Home",
                    Action = "Index",
                    Parameters = string.Empty,
                    Child = new[]
                    {
                        new Page()
                        {
                            Order = 0,
                            Id = "root/about",
                            Title = "About",
                            Summary = "サイトの構成や、制作者について、感想の類が書いてあります。",
                            Controller = "Home",
                            Action = "About",
                            Parameters = string.Empty,
                        },
                        new Page()
                        {
                            Order = 1,
                            Id = "root/gallery",
                            Title = "Gallery",
                            Summary = "授業で作成した成果物を陳列してあります。",
                            Controller = "Home",
                            Action = "Gallery",
                            Parameters = string.Empty,
                            Child = new[]
                            {
                                new Page()
                                {
                                    Order = 0,
                                    Id = "root/gallery/100720infoExpr",
                                    Title = "大学演習科目課題",
                                    Summary = "授業の課題で作成した成果物を陳列しています。",
                                    Description = "色々、授業の課題で作ったものや、作る過程で破棄されたもの等を陳列してます。",
                                    ThumbnailUrl = "~/gallery/100720infoExpr/image/thumb.jpg",
                                    Controller = "Gallery",
                                    Action = "List",
                                    Parameters = "article=100720infoExpr",
                                    Child = new[]
                                    {
                                        new Page()
                                        {
                                            Order = 0,
                                            Id = "root/gallery/100720infoExpr/0",
                                            Title = "第4-5回: plants animal",
                                            Summary = "Photoshopを使用し、素材から似たな部分を見つけて架空の生物を作成しました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k05th_animalplant/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=0"
                                        },
                                        new Page()
                                        {
                                            Order = 1,
                                            Id = "root/gallery/100720infoExpr/1",
                                            Title = "第6回: Flashアニメーション",
                                            Summary = "モーションガイドを利用したアニメーションを作成。蛇口から水滴が垂れる状況をFlashで表現しました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k06th_flashmotion/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=1",
                                        },
                                        new Page()
                                        {
                                            Order = 2,
                                            Id = "root/gallery/100720infoExpr/2",
                                            Title = "第7回: Flash動的表現",
                                            Summary = "ActionScriptを用いたインタラクティブな表現。スイッチの状態に合わせてコンビニおにぎりを切り替えるFlashを作成しました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k07th_flashas/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=2"
                                        },
                                        new Page()
                                        {
                                            Order = 3,
                                            Id = "root/gallery/100720infoExpr/3",
                                            Title = "第8回: HTMLのマークアップ",
                                            Summary = "関心のあるテーマでWeb ページを作成しました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k08th_html/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=3"
                                        },
                                        new Page()
                                        {
                                            Order = 4,
                                            Id = "root/gallery/100720infoExpr/4",
                                            Title = "第9回: CSSを加えたもの",
                                            Summary = "CSSを用いてウェブページのh1タグ等に装飾を施しました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k09th_htmlcss1/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=4"
                                        },
                                        new Page()
                                        {
                                            Order = 5,
                                            Id = "root/gallery/100720infoExpr/5",
                                            Title = "第10回: CSSページレイアウト",
                                            Summary = "第9回のCSSの学習をさらに進め、divタグを用いたページレイアウトやlistタグの挙動を変えたりしました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k10th_htmlcss2/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=5"
                                        },
                                        new Page()
                                        {
                                            Order = 6,
                                            Id = "root/gallery/100720infoExpr/6",
                                            Title = "第11回: リンク集",
                                            Summary = "これまでのHTML&CSSの知識を総動員し、お勧めのサイトを集めたリンク集を作りました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k11th_link/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=6"
                                        },
                                        new Page()
                                        {
                                            Order = 7,
                                            Id = "root/gallery/100720infoExpr/7",
                                            Title = "第12回:演習課題掲載サイト",
                                            Summary = "これまで授業で学んだの知識を総動員し、ウェブサイトを構築しました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/k12th_web/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=7"
                                        },
                                        new Page()
                                        {
                                            Order = 8,
                                            Id = "root/gallery/100720infoExpr/8",
                                            Title = "オブジェクト指向習作",
                                            Summary = "世界各国の首都をGoogleMapsを用いて表示してみました。",
                                            ThumbnailUrl = "~/gallery/100720infoExpr/oop_js/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100720infoExpr&id=8"
                                        },
                                    }
                                },
                                new Page()
                                {
                                    Order = 1,
                                    Id = "root/gallery/100823takao",
                                    Title = "夏季休暇課題",
                                    Summary = "高尾山の夏の動植物諸々、見つけた物を片っ端から撮って調べてみました。",
                                    Description = "高尾山は標高が低く都心からとても近い山ですが、とても動植物が多い山として知られています。今回は川が近くに流れる6号路を通りました。そのため、湿った場所に生える植物が沢山撮られています。また、ついでに写真のサイズについてですが、古いコンデジであるために低解像度&低感度&高ノイズ&手ブレ補正無しで、散々な写りとなってしまいました。そのため、縮小して誤魔化しています。ご容赦を。",
                                    ThumbnailUrl = "~/gallery/100823takao/image/thumb.jpg",
                                    Controller = "Gallery",
                                    Action = "List",
                                    Parameters = "article=100823takao",
                                    Child = new[]
                                    {
                                        new Page()
                                        {
                                            Order = 0,
                                            Id = "root/gallery/100823takao/0",
                                            Title = "ダイコンソウ",
                                            Summary = "バラ科ダイコンソウ属",
                                            ThumbnailUrl = "~/gallery/100823takao/dikn/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=0"
                                        },
                                        new Page()
                                        {
                                            Order = 1,
                                            Id = "root/gallery/100823takao/1",
                                            Title = "ゲジゲジシダ",
                                            Summary = "ヒメシダ科ヒメシダ属",
                                            ThumbnailUrl = "~/gallery/100823takao/gezi/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=1"
                                        },
                                        new Page()
                                        {
                                            Order = 2,
                                            Id = "root/gallery/100823takao/2",
                                            Title = "ハナイカダ",
                                            Summary = "ミズキ科ハナイカダ属",
                                            ThumbnailUrl = "~/gallery/100823takao/hana/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=2"
                                        },
                                        new Page()
                                        {
                                            Order = 3,
                                            Id = "root/gallery/100823takao/3",
                                            Title = "ヘビイチゴ",
                                            Summary = "バラ科ヘビイチゴ属",
                                            ThumbnailUrl = "~/gallery/100823takao/hebi/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=3"
                                        },
                                        new Page()
                                        {
                                            Order = 4,
                                            Id = "root/gallery/100823takao/4",
                                            Title = "イノデ",
                                            Summary = "オシダ科イノデ属",
                                            ThumbnailUrl = "~/gallery/100823takao/inod/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=4"
                                        },
                                        new Page()
                                        {
                                            Order = 5,
                                            Id = "root/gallery/100823takao/5",
                                            Title = "ヤマキツネノボタン",
                                            Summary = "キンポウゲ科キンポウゲ属",
                                            ThumbnailUrl = "~/gallery/100823takao/ktne/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=5"
                                        },
                                        new Page()
                                        {
                                            Order = 6,
                                            Id = "root/gallery/100823takao/6",
                                            Title = "ミズヒキ",
                                            Summary = "タデ科ミズヒキ属",
                                            ThumbnailUrl = "~/gallery/100823takao/mizk/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=6"
                                        },
                                        new Page()
                                        {
                                            Order = 7,
                                            Id = "root/gallery/100823takao/7",
                                            Title = "ミヤマフユイチゴ",
                                            Summary = "バラ科キイチゴ属",
                                            ThumbnailUrl = "~/gallery/100823takao/myic/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=7"
                                        },
                                        new Page()
                                        {
                                            Order = 8,
                                            Id = "root/gallery/100823takao/8",
                                            Title = "シャガ",
                                            Summary = "アヤメ科アヤメ属",
                                            ThumbnailUrl = "~/gallery/100823takao/shga/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=8"
                                        },
                                        new Page()
                                        {
                                            Order = 9,
                                            Id = "root/gallery/100823takao/9",
                                            Title = "タマアジサイ",
                                            Summary = "アジサイ科アジサイ属",
                                            ThumbnailUrl = "~/gallery/100823takao/tama/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=9"
                                        },
                                        new Page()
                                        {
                                            Order = 10,
                                            Id = "root/gallery/100823takao/10",
                                            Title = "ホオノキ",
                                            Summary = "モクレン科モクレン属",
                                            ThumbnailUrl = "~/gallery/100823takao/hono/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=10"
                                        },
                                        new Page()
                                        {
                                            Order = 11,
                                            Id = "root/gallery/100823takao/11",
                                            Title = "モミ",
                                            Summary = "マツ科モミ属",
                                            ThumbnailUrl = "~/gallery/100823takao/momi/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=11"
                                        },
                                        new Page()
                                        {
                                            Order = 12,
                                            Id = "root/gallery/100823takao/12",
                                            Title = "スダジイ",
                                            Summary = "ブナ科シイ属",
                                            ThumbnailUrl = "~/gallery/100823takao/sdzi/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=12"
                                        },
                                        new Page()
                                        {
                                            Order = 13,
                                            Id = "root/gallery/100823takao/13",
                                            Title = "ウラジロガシ",
                                            Summary = "ブナ科コナラ属",
                                            ThumbnailUrl = "~/gallery/100823takao/uraz/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=13"
                                        },
                                        new Page()
                                        {
                                            Order = 14,
                                            Id = "root/gallery/100823takao/14",
                                            Title = "カゴノキ",
                                            Summary = "クスノキ科カゴノキ属",
                                            ThumbnailUrl = "~/gallery/100823takao/kago/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=14"
                                        },
                                        new Page()
                                        {
                                            Order = 15,
                                            Id = "root/gallery/100823takao/15",
                                            Title = "粘板岩",
                                            Summary = "堆積岩",
                                            ThumbnailUrl = "~/gallery/100823takao/neba/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=15"
                                        },
                                        new Page()
                                        {
                                            Order = 16,
                                            Id = "root/gallery/100823takao/16",
                                            Title = "ザトウムシ",
                                            Summary = "クモ綱ザトウムシ目",
                                            ThumbnailUrl = "~/gallery/100823takao/zato/thumb.jpg",
                                            Controller = "Gallery",
                                            Action = "Detail",
                                            Parameters = "article=100823takao&id=16"
                                        },
                                    }
                                },
                                new Page()
                                {
                                    Order = 2,
                                    Id = "root/gallery/170128experiment",
                                    Title = "実験場",
                                    Summary = "色々試す場所",
                                    Description = "(´・ω・`)...",
                                    ThumbnailUrl = "~/gallery/170128experiment/image/thumb.gif",
                                    Controller = "Gallery",
                                    Action = "List",
                                    Parameters = "article=170128experiment",
                                },
                            }
                        },
                        new Page()
                        {
                            Order = 2,
                            Id = "root/product",
                            Title = "Product",
                            Summary = "色々、(中間)生成物を保管しています。",
                            Controller = "Home",
                            Action = "Product",
                            Parameters = string.Empty,
                            Child = new[]
                            {
                                new Page()
                                {
                                    Id = "root/product/snippet",
                                    Title = "Snippet",
                                    Summary = "このサイトを作成する際に作成したものを使いやすい形にして陳列しています。",
                                    ThumbnailUrl = "~/product/snippet/image/thumb.gif",
                                    Controller = "Snippet",
                                    Action = "Index",
                                    Parameters = string.Empty
                                }
                            }
                        }
                    }
                }
            );
            Group.AddRange(
                new Group()
                {
                    Id = 1,
                    UseBy = Page.Find("root/gallery/100720infoExpr"),
                    Page = new[]
                    {
                        Page.Find("root/gallery/100720infoExpr/0"),
                        Page.Find("root/gallery/100720infoExpr/1"),
                        Page.Find("root/gallery/100720infoExpr/2"),
                        Page.Find("root/gallery/100720infoExpr/3"),
                        Page.Find("root/gallery/100720infoExpr/4"),
                        Page.Find("root/gallery/100720infoExpr/5"),
                        Page.Find("root/gallery/100720infoExpr/6"),
                        Page.Find("root/gallery/100720infoExpr/7"),
                        Page.Find("root/gallery/100720infoExpr/8"),
                    }
                },
                new Group()
                {
                    Id = 2,
                    Title = "草",
                    UseBy = Page.Find("root/gallery/100823takao"),
                    Page = new[]
                    {
                        Page.Find("root/gallery/100823takao/0"),
                        Page.Find("root/gallery/100823takao/1"),
                        Page.Find("root/gallery/100823takao/2"),
                        Page.Find("root/gallery/100823takao/3"),
                        Page.Find("root/gallery/100823takao/4"),
                        Page.Find("root/gallery/100823takao/5"),
                        Page.Find("root/gallery/100823takao/6"),
                        Page.Find("root/gallery/100823takao/7"),
                        Page.Find("root/gallery/100823takao/8"),
                        Page.Find("root/gallery/100823takao/9"),
                    }
                },
                new Group()
                {
                    Id = 3,
                    Title = "木",
                    UseBy = Page.Find("root/gallery/100823takao"),
                    Page = new[]
                    {
                        Page.Find("root/gallery/100823takao/10"),
                        Page.Find("root/gallery/100823takao/11"),
                        Page.Find("root/gallery/100823takao/12"),
                        Page.Find("root/gallery/100823takao/13"),
                        Page.Find("root/gallery/100823takao/14"),
                    }
                },
                new Group()
                {
                    Id = 4,
                    Title = "他",
                    UseBy = Page.Find("root/gallery/100823takao"),
                    Page = new[]
                    {
                        Page.Find("root/gallery/100823takao/15"),
                        Page.Find("root/gallery/100823takao/16"),
                    }
                }
            );
            RootPin.AddRange(
                new Pin()
                {
                    Id = 1,
                    Title = Page.Find("root/gallery"),
                    Page = new[]
                    {
                        Page.Find("root/gallery/100720infoExpr"),
                        Page.Find("root/gallery/100823takao"),
                    }
                },
                new Pin()
                {
                    Id = 2,
                    Title = Page.Find("root/product"),
                    Page = new[]
                    {
                        Page.Find("root/product/snippet"),
                    }
                }
            );
            ContentCard.AddRange(
                new ContentCard()
                {
                    Order = 0,
                    Type = CardType.Text,
                    Title = "this site...",
                    Content = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}Data/Files/sitedesc.html"),
                    Owner = Page.Find("root/about")
                },
                new ContentCard()
                {
                    Order = 1,
                    Type = CardType.Text,
                    Title = "namoshika's Profile",
                    Content = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}Data/Files/ownerdesc.html"),
                    Owner = Page.Find("root/about")
                },
                new ContentCard()
                {
                    Order = 2,
                    Type = CardType.Text,
                    Title = "サイト制作について",
                    Content = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}Data/Files/comment.html"),
                    Owner = Page.Find("root/about")
                },
                new ContentCard()
                {
                    Order = 0,
                    Type = CardType.Text,
                    Title = "パンくずリスト生成用PHP",
                    Content = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}Data/Files/breadcrumb.html"),
                    Owner = Page.Find("root/product/snippet")
                },
                new ContentCard()
                {
                    Order = 1,
                    Type = CardType.Text,
                    Title = "更新履歴生成用PHP",
                    Content = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}Data/Files/timeline.html"),
                    Owner = Page.Find("root/product/snippet")
                }
            );
            ContentInfoExpr.AddRange(
                new ContentInfoExpr()
                {
                    Content = "<img class='picture' src='k05th_animalplant/anmlPlnt.jpg' alt='picture' />",
                    Subject = "素材集の中から、植物と動物の形態・テクスチャーをよく観察し、お互いの相似な部分を見つけて、ひとつの新たな架空の生物として合成しなさい。あくまで植物と動物の色や形、テクスチャーなどの「似たところ」をうまく見立てて、両者を結びつけて自然に見えるように合成してください。合成に使用する素材は、植物1種類、動物1種類の2つとします。",
                    Comment = "キャベツの葉の重なり具合がダチョウのモサモサに似ているように思えたため、合成しました。当初は、これは練習目的だったのですが、本命のトウモロコシと動物の皮膚の合成が出来の悪い模型の珍獣になってしまい、これを本番としました。合成において、艶のある物体の扱いが難しいというのは意外でした。",
                    Owner = Page.Find("root/gallery/100720infoExpr/0")
                },
                new ContentInfoExpr()
                {
                    Content = "<embed class='picture' src='k06th_flashmotion/k6th.swf' width='320' height='228' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed>",
                    Subject = "任意にテーマを選んでモーションガイドを利用したアニメーションを作成すること。具体的なモチーフを選び、それに相応しい自然な動きのアニメーションを作成してほしい。なお、ボタンを1つ作り、クリックするたびにアニメーションが見られるようにすること。",
                    Comment = "モーショントゥーインの動きに魅せられて作りました。個人的には一番良く出来たかと思っています。課題自体はモーションガイドを使わなければならない課題であったため、どのようにモーションガイドが必要になる動きを組み込むかにとても悩みました。結果的に最後の水滴が小さい物体に衝突し、飛び散る動きで使用しましたが、そんなものはどうでもいいです。蛇口から水滴が出来、蛇口から離れるまでが全てです。",
                    Owner = Page.Find("root/gallery/100720infoExpr/1")
                },
                new ContentInfoExpr()
                {
                    Content = "<embed class='picture' src='k07th_flashas/k07th.swf' width='320' height='245' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed>",
                    Subject = "インタラクティブなFlashコンテンツを作成する。同じ場面で4つの異なる情況を各自で考えて撮影し、ON/OFFスイッチに合わせて4通りの画像が切り替わるようにすること。",
                    Comment = "当初思いついたのは、頭皮が荒野となっている人の頭上を光らせるスイッチだったのですが、著作権やら名誉が云々で面倒だと思ったために色々考えた末、コンビニのおにぎりになりました。見どころは本来、剥がしたら戻せないはずの表面の包装がスイッチを切るだけで戻せる点です。現実じゃこうはいきません。普段趣味で使う開発環境はVisualStudioなのでFlashの開発環境のActionScriptの編集機能の貧弱さに戸惑いました。",
                    Owner = Page.Find("root/gallery/100720infoExpr/2")
                },
                new ContentInfoExpr()
                {
                    Content = "<a href='k08th_html/contents/k08th.html' class='picture'><img class='picture' src='k08th_html/contentsSS.jpg' alt='picture' /></a>",
                    Subject = "自分が興味・関心のある題材を用いて 、Web ページ（1ページだけでよい）を作成してください。",
                    Comment = "課題が課された当時に着手していたデジタルデータ基礎のレポート課題の書きかけの形式が見出しやテーブル等で今回の課題で使う必要のあるタグに一致していたため、コピーせずして何がデジタルデータだと思いながら再利用しました。Wordの表をTableタグに移すのが大変でした。",
                    Owner = Page.Find("root/gallery/100720infoExpr/3")
                },
                new ContentInfoExpr()
                {
                    Content = "<a href='k09th_htmlcss1/contents/k09th.html' class='picture'><img class='picture' src='k09th_htmlcss1/contentsSS.jpg' alt='picture' /></a>",
                    Subject = "第8回目の課題の生成物を基にCSSを用いて Web ページに独自のスタイルを設定してください。",
                    Comment = "授業で扱ったサンプル教材のCSSを参考にそのままやりました。特に感想は無い。",
                    Owner = Page.Find("root/gallery/100720infoExpr/4")
                },
                new ContentInfoExpr()
                {
                    Content = "<a href='k10th_htmlcss2/contents/kadai_p1.html' class='picture'><img class='picture' src='k10th_htmlcss2/contentsSS.jpg' alt='picture' /></a>",
                    Subject = "第9回目の課題で作成した Web ページにレイアウトを設定してください。",
                    Comment = "IEのレンダリングエンジンのバグやCSSの珍仕様に度々遭遇し、ひどく疲弊しました。早くIEがインターネットから消えて欲しいと思うのは勿論、CSSの癖のある動きへもうんざりさせられました。仕様が統一されている面でFlashが素晴らしく思えました。",
                    Owner = Page.Find("root/gallery/100720infoExpr/5")
                },
                new ContentInfoExpr()
                {
                    Content = "<a href='k11th_link/contents/links.html' class='picture'><img class='picture' src='k11th_link/contentsSS.jpg' alt='picture' /></a>",
                    Subject = "あなたが是非みんなに教えてあげたいと思うお勧めのサイトを集めたリンク集を作って下さい。",
                    Comment = "今回のウェブページを作る課題でも使えるCSSを書こうと思い、意気込んでデザインを作りました。意識した点としては使いまわしが効くようにclass設定を用いて各デザインの要素を性質ごとに分割しました。だいぶレンダリングエンジンのバグやCSSの珍仕様にも慣れたためにCSSに悩む事はだいぶ減りました。紹介しているサイトは自分のはてなブックマークから探しましたが、動画リンクサイト等が多かったために真面目なサイトを探すのに苦労しました。",
                    Owner = Page.Find("root/gallery/100720infoExpr/6")
                },
                new ContentInfoExpr()
                {
                    Content = "<a href='k12th_web/contents/index.html' class='picture'><img class='picture' src='k12th_web/contentsSS.jpg' alt='picture' /></a>",
                    Subject = "これまでの演習課題を掲載したWebページを作成する。なお、ページデザインはほぼ自由で各自の好みである。",
                    Comment = "当サイトの初期ver1.0です。ver1.0まで掲載しろとは言われてませんが折角なので載せました。ただ、画像等が現バージョンと共有なので一部おかしいです。CSSが第11回の演習課題で作成したものを継承したために似ています。認識している問題点として、パンくずリストは途中で付け加えたために少々分かりずらいものとなってしまっています。そのため、現バージョンでは改善しました。また、この頃からCSSのLayoutとColorを別ファイルとして分離するようになったために容易にColorを全面変更する事が出来るようになりました。現バージョンでは汎用性の高い外見のLayoutとColorに1つ用意し、ページ共通のLayoutとColorに2つ。個別のページのLayoutとColorで2つに分けています。ちなみに夏季休暇課題で作成したver2.0は当然ver1.0のCSSを改良するはずで、休暇前にベースの大部分が既に出来ていたのですが、タギング方法を文章構造重視にした為に大部分が書きなおす事となり、現verは3.0とも言えます。",
                    Owner = Page.Find("root/gallery/100720infoExpr/7")
                },
                new ContentInfoExpr()
                {
                    Content = "<a href='oop_js/contents/index.html' class='picture'><img class='picture' src='oop_js/contentsSS.jpg' alt='picture' /></a>",
                    Subject = "授業で学んだことを活かして世界各国の首都の説明と場所を表示するページを作成してください。",
                    Comment = "当時のコードは結合度の設計が甘かったため再構成したものを公開。JavaScriptの進化に合わせて今時な機能を使用してTypeScriptでまとめました。",
                    Owner = Page.Find("root/gallery/100720infoExpr/8")
                }
            );
            ContentTakao.AddRange(
                new ContentTakao()
                {
                    Content = "<img src='dikn/image.jpg' class='picture' />",
                    Comment = "登山の始めの方の沢に近づく道あたりでシダやらシャガに混じって見つけました。この植物は多年草で、耐寒性で冬は地上部を枯らす宿根性だそうです。各地の渓谷付近等のやや湿った場所に生え、7月～8月あたりに花を咲かせます。葉の形状が大根の葉に似ている事からこの名が名づけられて様ですが、大根がアブラナ科である一方、ダイコンソウはバラ科のため全く縁が無い感じです。また、自生種としてダイコンソウ属内でチングルマ等の同属が存在しますがダイコンソウ以外は高山に生える植物で、園芸種ではゲウムが同属です。花の先端にはフックの様な柱頭があり、服に引っかかる感じです。",
                    Owner = Page.Find("root/gallery/100823takao/0")
                },
                new ContentTakao()
                {
                    Content = "<img src='gezi/image.jpg' class='picture' />",
                    Comment = "琵琶滝までの道に沢山生えていました。この植物はゲジゲジみたいな葉の生え方からそう呼ばれているそうです。",
                    Owner = Page.Find("root/gallery/100823takao/1")
                },
                new ContentTakao()
                {
                    Content = "<img src='hana/image.jpg' class='picture' />",
                    Comment = "琵琶滝付近の沢に平行した道で見つけました。この植物は落葉性で低木で、5月～6月あたりに花を咲かせるそうです。特徴的な点として葉の中央に花を咲かせる点が挙げられ、8月時点では実になっていましたが見つけた時のインパクトは実でも十分でした(始めは別の植物が貫通しているのかと思いました)。名前の由来も葉をイカダに見立てたものだそうです。また、オスとメスの株があり、小学生時に育てたヘチマ以上に面倒な植物に思えます。写真撮影時には既に実の段階であったためにオスを見る事が出来ませんでしたが、メスの花は葉の上に通常1個出来るのに対し、オスの花は数個出来る様です。実は甘みがあり、食べられるそうです。",
                    Owner = Page.Find("root/gallery/100823takao/2")
                },
                new ContentTakao()
                {
                    Content = "<img src='hebi/image.jpg' class='picture' />",
                    Comment = "シダ&シャガに混じってましたが、野原や水田に生える多年草だそうです。これは自宅近くの小さい山でも見かけたりしますが、この植物は4月～6月あたりに黄色い5枚の花弁を持った花が咲くそうです。また、今まで有毒植物と思ってましたが違うようです。しかし、味が無く、不味いらしいです。また、名前の由来として蛇が食べるイチゴや蛇が獲物を狙うための餌代わり等言われているようですが良く分かりません。同属としてヤブヘビイチゴという種類があり、こちらはヘビイチゴよりも生える地域が限られており、実が赤く、光沢があり、林の縁等の光が少ない場所に生え、葉も色が濃いという違いがあるようですが、写真のがどっちかは分かりませんでした。",
                    Owner = Page.Find("root/gallery/100823takao/3")
                },
                new ContentTakao()
                {
                    Content = "<img src='inod/image.jpg' class='picture' />",
                    Comment = "ゲジゲジ等のシダに混じってシダの仲間のイノデが生えてました。シダにも種類がありますが、イノデ内でも複数の種類があり、シダ植物門オシダ科イノデ属と言う形でまとめられているのですが、その種類の中で雑種がどんどん出来るため、色々あるようです。ちなみに、そのどれに写真が属しているのかは良く分かりませんでした。名前の由来は新芽がイノシシの足のように毛むくじゃらな様子からそのように名付けられたようですが、確かに毛むくじゃらのようです(<a href=\"http://www.google.co.jp/images?q=%E3%82%A4%E3%83%8E%E3%83%87+%E6%96%B0%E8%8A%BD\" target=\"_blank\">Google</a>)。",
                    Owner = Page.Find("root/gallery/100823takao/4")
                },
                new ContentTakao()
                {
                    Content = "<img src='ktne/image.jpg' class='picture' />",
                    Comment = "これも琵琶滝までの道でシダの類に混じって生えており、ヤマキツネノボタンと言うそうです。日本各地に生えており、水田周辺の水路や溝、畦など、湿り気のある場所に生え、5月から7月あたりに花を咲かせる多年生の草本だそうです。花はかなり黄色いです。また、咲いた後に中央に出来る実は、複数の実が集合して出来ており、一つ一つの実には鍵状の突起が付いているために服に引っかかります。この果実の形状から、別名ではコンペイトウグサとも言うそうです。また、ヤマが抜けたキツネノボタンという種類もあり、ヤマの方が毛が多いそうです。違いが良く分かりませんが頂上のビジターセンターで紹介されていたのがヤマの方でしたし、山に生えていたので多分写真のはヤマの方なんでしょう。ちなみにトリカブト等、キンポウゲ科の植物には毒を持つものが多く、キツネノボタンも有毒植物だそうです。そのため、植物の汁に触れるとかぶれ、食べると消化器が炎症を起こします。よって、服に付いた実を包装材のプチプチみたく潰して遊ばないようにしましょう。",
                    Owner = Page.Find("root/gallery/100823takao/5")
                },
                new ContentTakao()
                {
                    Content = "<img src='mizk/image.jpg' class='picture' />",
                    Comment = "この植物は写真は撮ったのですが発見場所を忘れました。たぶんシャガ付近でしょう。写真に写ってますし。この植物は山の林縁や路傍に生える多年草で、8月～10月あたりに花を咲かせるそうです。花弁が無く、写真の赤く見えるのは\"がく\"だそうです。そして時期によって葉が八のような模様が付く様です。写真から分かるように、高さが30cm～80cmの茎に花が直接出てきています。また、種が服などにくっ付いて運ばれます。",
                    Owner = Page.Find("root/gallery/100823takao/6")
                },
                new ContentTakao()
                {
                    Content = "<img src='myic/image.jpg' class='picture' />",
                    Comment = "登り始めのシダの生えてる辺りで見つけました。この植物は山や川岸に生える常緑樹で、つる性の茎は地面を這い、棘を持つそうです。深山と書いてミヤマと読みますが、高尾山という低山に生えてしまう浅山苺です。9月～10月にかけて白い花を咲かせ、１１月～１月あたりに赤い果実が実り、食べられるそうです。同属としてフユイチゴという似た種が有りますが、こちらは棘が無く、葉はミヤマフユイチゴよりも先端が丸くなっているそうですが、他は殆ど一緒どころか雑種まで出来てしまうために区別が難しかったりするようです。",
                    Owner = Page.Find("root/gallery/100823takao/7")
                },
                new ContentTakao()
                {
                    Content = "<img src='shga/image.jpg' class='picture' />",
                    Comment = "登山中盤までよく見かけた気がします。この植物はやや湿った場所に生える常緑性の多年草で、4月～5月あたりに花を咲かせるそうです。細長い光沢のある葉がいたる所で群生しており、山の斜面を支える事が役割があるそうです。8月に来たので当然花は有りませんでしたが、花は1日で萎んでしまい、種子は作らないそうです。この植物はどうやら中国から持ち込まれたものが野生化したものらしいです。",
                    Owner = Page.Find("root/gallery/100823takao/8")
                },
                new ContentTakao()
                {
                    Content = "<img src='tama/image.jpg' class='picture' />",
                    Comment = "数は多くないですが、山の上から下まで何処にでも生えてました。この植物は中部から関東までと福島県、岐阜県あたりに生えており、湿った場所に生える木で、7月～9月あたりに花を咲かせるそうです。良く知られている紫陽花は6月から7月あたりに花が咲くため、タマアジサイはかなり遅咲きと言えます。蕾の形が球体となっており、これが名前の由来となっています。また、写真からも分かりますが、一斉に花が咲く訳ではなく、順次球体が破れたように開いていきます。その為に余計に花を長期間見る事が出来るのと同時に、見た目が木全体で見た時にダサいです。知らなかったのですが、アジサイは当種も普通のも同様に有毒らしいです。カッコつけてカクテルに添えない様にしましょう。確か梅も同様の成分を含むので焼酎に漬ければ食えるかもしれません。",
                    Owner = Page.Find("root/gallery/100823takao/9")
                },
                new ContentTakao()
                {
                    Content = "<img src='hono/image.jpg' class='picture' />",
                    Comment = "琵琶滝までより前の道に生えていました。この木は落葉広葉樹で山地の河川等の土壌の厚い場所に生えている木で、5月～6月に花が咲くそうです。また、とても大きな葉を付ける木で、葉は20～40cm程の葉が付き、高尾山の植物の中では最も葉が大きい木です。そして幹が真っすぐに伸び、葉は上の方に付くために近くで葉を撮る事は出来ませんでした。木材としては上質でやわらかいために細工し易く、木細工や家具などに使われ、葉は殺菌作用があり、香りも良いために食べ物を包む際の食器代わりや、朴葉味噌への利用として活用され、樹皮は乾燥されて健胃薬として使われたりするそうです。葉の活用先として朴葉餅が有名だそうですが、これは柏餅に似ています。",
                    Owner = Page.Find("root/gallery/100823takao/10")
                },
                new ContentTakao()
                {
                    Content = "<img src='momi/image.jpg' class='picture' />",
                    Comment = "撮影場所を忘れましたが、けっこう何処にでも生えてますね。常緑針葉樹で日本の特産種で20m～30mの高さになり、木材は軽くてやわらかく、加工しやすいために建築や器具材、マッチの軸、パルプなどに利用されるそうです。しかし、大気汚染に弱く都市での栽培に向かないそうです。",
                    Owner = Page.Find("root/gallery/100823takao/11")
                },
                new ContentTakao()
                {
                    Content = "<img src='sdzi/image.jpg' class='picture' />",
                    Comment = "これも撮影場所忘れました。モミと同じく下山路に生えていました。常緑広葉樹林で葉は厚く深緑色。幹は黒褐色で、成長すると樹皮に縦の切れ目が入るのが特徴らしいです。ちなみに左上を見るとわかりますが、木にスダジイと名前が書いてあったので、この木は間違いなくスダジイです。他のは看板が架かってないので確信が持てなかったりします。",
                    Owner = Page.Find("root/gallery/100823takao/12")
                },
                new ContentTakao()
                {
                    Content = "<img src='uraz/image.jpg' class='picture' />",
                    Comment = "これも撮影場所忘れました。前のと同じく下山路です。樹皮は暗褐色から灰色で滑らか。高さは20cm以上に達します。葉の裏側が白色となっており、これが名前の由来となっています。この手の木の実が\"どんぐり\"と呼ばれるらしいですが、\"どんぐり\"が何者か考えた事が無かったのでへぇ～と思いました。",
                    Owner = Page.Find("root/gallery/100823takao/13")
                },
                new ContentTakao()
                {
                    Content = "<img src='kago/image.jpg' class='picture' />",
                    Comment = "これも撮影場所忘れました。前のと同じく下山路です。常緑樹で樹皮がまばらに剥がれ落ち、鹿の子模様になる点から「鹿子の木(かごのき)」と呼ばれています。8月～9月に花が咲くそうです。また、葉は特徴に欠け、葉のみで種を特定するのは難しいそうです。",
                    Owner = Page.Find("root/gallery/100823takao/14")
                },
                new ContentTakao()
                {
                    Content = "<img src='neba/image.jpg' class='picture' />",
                    Comment = "琵琶滝付近で露出していました。堆積岩の一種で、海底の砂や泥が自然の力で押し固められる事によって生成されるそうです。とても硬く、高密度できめ細かい構造をしており、薄く割れやすく風化しにくく、そして磨くと表面がツルツルになります。見る事が出来たのは黒色の粘板岩でしたが、赤や緑、紫色なのもあるそうです。主に瓦や堀、硯、囲碁の黒石などに利用されるそうです。",
                    Owner = Page.Find("root/gallery/100823takao/15")
                },
                new ContentTakao()
                {
                    Content = "<img src='zato/image.jpg' class='picture' />",
                    Comment = "琵琶滝以降の道で木の割れ目の間に2匹いました。この虫は中型の蜘蛛の仲間ですが、糸は出さず、頭胸部と腹部の間にくびれが無く、変わっています。この虫は身体が頭胸部と腹部の2つから構成されておらず、全て一個に収まっている点でダニっぽいです。そして、とにかく足が長く、この足の長さを活かして前方をゆさゆさと進んでいくため、気持ち悪いです。主に虫やその死骸を食べるため、頂上のビジターセンターでは森の掃除屋とされていました。視覚は明暗程度しか認識できないためにほぼ盲目といえ、視覚の代わりに周囲の振動を足で感知し、周囲を把握しているようです。まさに座頭虫と言えます。加えて、ザトウムシはピンチの時に足を自切するらしいです。なお、ザトウムシ目の中にも幾つか種類があるようですが写真のがどれに属すかはちょっと分かりませんでした。ちなみに「千と千尋の神隠し」で劇中に登場する「釜爺」のモデルはこれらしいです。釜爺も湯婆婆に絡まれた時に自切すれば湯屋でパシられる契約を結ばずに済んだのかもしれません。",
                    Owner = Page.Find("root/gallery/100823takao/16")
                }
            );
            UpdateHistory.AddRange(GetHistory());
            SaveChanges();
        }
        List<UpdateLog> GetHistory()
        {
            var http = new System.Net.Http.HttpClient();
            http.DefaultRequestHeaders.Add("Accept", "application /json");
            http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            var json = http.GetStringAsync("https://api.github.com/repos/namoshika/NamoshikaSite/commits").Result;
            var res = Newtonsoft.Json.Linq.JArray.Parse(json);
            var history = new List<UpdateLog>();
            foreach (dynamic item in res)
            {
                var date = item.commit.committer.date;
                var message = item.commit.message;
                history.Add(new UpdateLog() { Date = date, Message = message });
            }
            return history;
        }
    }
}
