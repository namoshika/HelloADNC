<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>簡易アンケート v00</title>
</head>
<body>
	<p>あなたの名前は<?php echo $_POST["namae"]; ?>ですね</p>
	<p>あなたの性別は<br /><?php echo $_POST["gender"] == "male" ? "男性" : "女性"; ?>ですね</p>
	<p>
		あなたの好きな果実は<br />
		<?php
			if($_POST["orange"] != null){
				foreach($_POST["orange"] as $idx => $val)
				{
					switch($val){
						case "いちご":
							echo "いちご<br />";
							break;
						case "みかん":
							echo "みかん<br />";
							break;
						case "すいか":
							echo "すいか<br />";
							break;
						case "メロン":
							echo "メロン<br />";
							break;
						case "バナナ":
							echo "バナナ<br />";
							break;
					}
				}
			}
		?>
		ですね
	</p>
	<p>
		あなたの関心があるのは<br />
		<?php
			if($_POST["hobby"] != null){
				foreach($_POST["hobby"] as $idx => $val)
				{
				switch($val){
						case "映画":
							echo "映画<br />";
							break;
						case "音楽":
							echo "音楽<br />";
							break;
						case "読書":
							echo "読書<br />";
							break;
						case "スポーツ":
							echo "スポーツ<br />";
							break;
					}
				}
			}
		?>
		ですね
	</p>
	<p>
		あなたの出身の地域は<br />
		<?php
			switch($_POST["region"]){
				case 0:
					echo "北海道";
					break;
				case 1:
					echo "東京";
					break;
				case 2:
					echo "京都";
					break;
			}
		?></p>
	<p>あなたのコメントは<?php echo $_POST["comment"]; ?>ですね</p>
	<p>
		<?php
			foreach($_POST as $idx => $val)
			{
				echo $idx."：".$val."<br />";
			}
		?>
	</p>
</body>
</html>