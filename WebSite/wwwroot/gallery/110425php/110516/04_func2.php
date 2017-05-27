<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>関数を使用する</title>
</head>
<body>
	<?php
		function get_total_charge($kingaku)
		{
			global $tax;
			$service = 1.1;
			$tax = 1.05;

			echo "<p>利用明細</p>";
			echo "<p>消費税:".$tax."</p>";
			echo "<p>サービス料:".$service."</p>";

			return $kingaku * $service * $tax;
		}

		echo "<p>合計金額:".get_total_charge(1000)."</p>";
	?>
</body>
</html>