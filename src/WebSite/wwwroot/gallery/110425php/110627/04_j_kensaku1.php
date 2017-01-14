<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<title>住所録全件表示</title>
</head>
<body>
	<?php
		extract($_POST);
		if($nam === null){
	?>
	<p>検索する氏名の一部を入力する。</p>
	<form method="post" action="<?php $_SERVER["PHP_SELF"]; ?>">
		<p>検索氏名：<input type="text" name="nam" value="<?php $nam; ?>" size="40"></p>
		<p>
			<input type="submit" value="検索" />
			<input type="reset" value="リセット" />
		</p>
	</form>
	<?php
		}else{
			$url = "db2.ne.senshu-u.ac.jp";
			$user = "webprog13";
			$pass = "tokushu2011";
			$db = "webprog13";

			mysql_connect($url, $user, $pass) or die("データベースの接続に失敗しました");
			mysql_select_db($db) or die("データベースの選択に失敗しました");

			$sql = "select * from jushoroku where simei like '%{$nam}%'";
			$result = mysql_query($sql);
			$row = mysql_num_rows($result);

			if ($row === null){
				echo "<p>該当データがありません。</p>";
			}else{
				while ($row = mysql_fetch_array($result)){
					echo "<p>";
					echo "{$row["renban"]}　{$row["tourokubi"]}<br />";
					echo "{$row["simei"]}　{$row["yubin1"]}－{$row["yubin2"]}　{$row["jusho1"]}{$row["jusho2"]}<br />";
					echo "TEL　{$row["denwa"]}　FAX　{$row["fax"]}　CELL　{$row["keitai"]}　MAIL　{$row["meruado"]}<br />";
					echo $row["biko"];
					echo "</p><hr />";
				}
			}
		}
	?>
</body>
</html>