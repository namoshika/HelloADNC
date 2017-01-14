<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<link rel="stylesheet" href="order_style.css" />
	<title>商品注文画面 v00</title>

	<?php
	//定義
	class OrderClass{
		public function __construct($itemId, $name, $sendAddress, $recievableTimeId, $isForPresent, $comment){
			$this->itemId = $itemId;
			$this->name = $name;
			$this->sendAddress = $sendAddress;
			$this->recievableTimeId = $recievableTimeId;
			$this->isForPresent = $isForPresent;
			$this->comment = $comment;
		}
		public $itemId;
		public $name;
		public $sendAddress;
		public $recievableTimeId;
		public $isForPresent;
		public $comment;
	}
	
	//処理
	session_start();
	$orderAry = array();
	foreach($_SESSION["orders"] as $val){
		$orderAry[] = unserialize($val);
	}
	?>
</head>
<body>
	<h1>商品注文画面</h1>
	<p>現在、以下の入力内容となっております。お間違いないでしょうか</p>
	<div class="orderparam">
		<h2>商品</h2>
		<ul>
			<?php
			foreach($orderAry as $orderObj){
				echo "<li>";
				switch($orderObj->itemId){
					case 0:
						echo "<b>商品：PHP入門(1000円)</b><br />";
						break;
					case 1:
						echo "<b>商品：PHP入門の入門(1000円)</b><br />";
						break;
					case 2:
						echo "<b>商品：PHP入門の入門の入門(1000円)</b><br />";
						break;
					case 3:
						echo "<b>商品：PHP入門の入門の入門の入門(1000円)</b><br />";
						break;
				}
				echo "名前：{$orderObj->name}<br />";
				echo "送付先：{$orderObj->sendAddress}<br />";
				echo "配送の希望時間：";
				switch($orderObj->recievableTimeId){
					case 0:
						echo "午前";
						break;
					case 1:
						echo "午後";
						break;
					case 2:
						echo "夜間";
						break;
				}
				echo "<br />プレゼント用の包装：".($orderObj->isForPresent == true ? "有" : "無")."<br />";
				echo "他のご要望：{$orderObj->comment}<br />";
				echo "</li>";
			}
			?>
		</ul>
	</div>
	<div class="orderparam">
		<h2>合計金額</h2>
		<p>
			<?php
			$totalPrice = 0;
			foreach($orderAry as $orderObj){
				switch($orderObj->itemId){
					case 0:
						$totalPrice += 1000;
						break;
					case 1:
						$totalPrice += 1000;
						break;
					case 2:
						$totalPrice += 1000;
						break;
					case 3:
						$totalPrice += 1000;
						break;
				}
			}
			echo $totalPrice."円";
			?>
		</p>
	</div>
</form>
<a href="05_order.php">さらに注文する</a><br />
</body>
</html>