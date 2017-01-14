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
	if($_SESSION["orders"] === null){
		$_SESSION["orders"] = array();
	}
	
	//処理
	session_start();
	if($_POST["item"] !== null && $_POST["namae"] !== null && $_POST["itemtarget"] !== null
	&& $_POST["hopetime"] !== null){

		$orderObj = new OrderClass(
			$_POST["item"], $_POST["namae"], $_POST["itemtarget"], $_POST["hopetime"],
			$_POST["options"][0] === "forpresent", (string)$_POST["comment"]);
		$_SESSION["orders"][] = serialize($orderObj);
	}else{
		$orderObj = null;
	}
	?>
</head>
<body>
	<h1>商品注文画面</h1>
	<p>現在、以下の入力内容となっております。お間違いないでしょうか</p>
	<div class="orderparam">
		<h2>商品</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				switch($orderObj->itemId){
					case 0:
						echo "PHP入門(1000円)";
						break;
					case 1:
						echo "PHP入門の入門(1000円)";
						break;
					case 2:
						echo "PHP入門の入門の入門(1000円)";
						break;
					case 3:
						echo "PHP入門の入門の入門の入門(1000円)";
						break;
				}
			}
			?>
		</p>
	</div>
	<div class="orderparam">
		<h2>お名前</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				echo $orderObj->name;
			}
			?>
		</p>
	</div>
	<div class="orderparam">
		<h2>送付先</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				echo $orderObj->sendAddress;
			}
			?>
		</p>
	</div>
	<div class="orderparam">
		<h2>配送の希望時間</h2>
		<?php
		if($orderObj == null){
			echo "Error";
		}else{
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
		}
		?>
	</div>
	<div class="orderparam">
		<h2>オプション</h2>
		<ul class="listup">
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				if($orderObj->isForPresent == true){
					echo "贈り物用包装希望";
				}else{
					echo "無し";
				}
			}
			?>
		</ul>
	</div>
	<div class="orderparam">
		<h2>他のご希望</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				echo $orderObj->comment;
			}
			?>
		</p>
	</div>
	<a href="05_order.php">さらに注文する</a><br />
	<a href="07_order_total.php">注文した全商品を見る</a>
</form>
</body>
</html>