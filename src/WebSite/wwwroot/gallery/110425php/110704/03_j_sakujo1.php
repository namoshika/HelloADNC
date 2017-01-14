<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<title>住所録削除</title>
</head>
<body>
	<?php
		extract($_POST);
		extract($_GET);

		$url = "db2.ne.senshu-u.ac.jp";
		$user = "webprog13";
		$pass = "tokushu2011";
		$db = "webprog13";

		mysql_connect($url, $user, $pass) or die("データベースの接続に失敗しました");
		mysql_select_db($db) or die("データベースの選択に失敗しました");

		if($kakunin == "確認"){
			$sql = "delete from jushoroku where renban={$ren}";
			echo $sql."<br />";
			mysql_query($sql);
			echo "レコードの削除が完了しました";
			exit;
		}

		$sql = "select * from jushoroku where renban={$id}";
		$result = mysql_query($sql);
		$row = mysql_num_rows($result);
		if ($row == 0){
			echo "<p>該当データがありません。</p>";
		}else{
			while ($row = mysql_fetch_array($result)){
				echo "<p>このレコードを削除してください</p>";
				echo "<form action=\"{$_SERVER["PHP_SELF"]}\" method=\"post\">";
				echo "<p>連番：{$row["renban"]}</p>";
				echo "<p>登録日：{$row["tourokubi"]}</p>";
				echo "<p>氏名：{$row["simei"]}</p>";
				echo "<p>郵便番号：{$row["yubin1"]}-{$row["yubin2"]}</p>";
				echo "<p>住所1：{$row["jusho1"]}</p>";
				echo "<p>住所2：{$row["jusho2"]}</p>";
				echo "<p>TEL：{$row["denwa"]}</p>";
				echo "<p>FAX：{$row["fax"]}</p>";
				echo "<p>ケータイ：{$row["keitai"]}</p>";
				echo "<p>MAIL：{$row["meruado"]}</p>";
				echo "<p>備考：{$row["biko"]}</p>";

				echo "<input type=\"hidden\" name=\"ren\" value=\"{$row["renban"]}\" />";

				echo "<p><input type=\"submit\" name=\"kakunin\" value=\"確認\">";
				echo "<p><input type=\"reset\" value=\"リセット\">";
				echo "</form>";
			}
		}
	?>
</body>
</html>