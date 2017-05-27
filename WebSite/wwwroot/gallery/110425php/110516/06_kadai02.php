<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>課題2</title>
</head>
<body>
	<?php
		$gusu = 0;
		$kisu = 0;
		for($i = 1; $i <= 100; $i++){
			if($i % 2 == 0){
				$gusu++;
			}else{
				$kisu++;
			}
		}
	?>
	<p>1から100までの偶数値の合計は<?php echo $gusu; ?></p>
	<p>1から100までの奇数値の合計は<?php echo $kisu; ?></p>
</body>
</html>