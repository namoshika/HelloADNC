<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
	<title>課題詳細</title>
	<?php
	require 'common/php/dataClasses.php';
	require 'common/php/headerHeader.php';

	mysql_connect('db2.ne.senshu-u.ac.jp', 'webprog13', 'tokushu2011');
	mysql_select_db('webprog13');

	$loadedTaskInfos = array();
	$usrCode = $_SESSION["userId"];
	$res = mysql_query("select A.id as taskid, B.id as subjectid, B.name as subjectname, A.name as taskname, A.limitdate, A.priority, A.state, A.memo from tskmng_registtask as A inner join tskmng_subject as B on A.subjectid = B.id where A.personid = {$usrCode} order by A.limitdate");
	while($row = mysql_fetch_array($res)){
		$loadedTaskInfos[] = new TaskInfo($row["taskid"], $row["subjectid"], $row["subjectname"], $row["taskname"], $row["limitdate"], $row["priority"], $row["state"], $row["memo"]);
	}
	?>
</head>
<body>
	<?php require 'common/php/bodyHeader.php'; ?>
	<div class="mainDiv">
		<div id="taskQuickEditDiv">
			<h2>操作</h2>
			<p>新たに課題を...</p>
			<ul>
				<li><a href="edit.php">追加する</a></li>
			</ul>
		</div>
		<div id="taskListDiv">
			<h2>課題リスト</h2>
			<ul>
				<?php
				$tskLst = new TaskList($loadedTaskInfos, time());
				//print(count($tskLst->taskWeekLists));

				foreach ($tskLst->taskWeekLists as $tsks){
					echo "<li class=\"taskGroup\">\n";
					switch ($tsks->weekOffset){
						case 0:
							echo "<h3>今週中</h3>\n";
							break;
						case 1:
							echo "<h3>来週中</h3>\n";
							break;
						case 2:
							echo "<h3>来週以降</h3>\n";
							break;
					}
					echo "<ul class=\"taskList\">\n";
					foreach ($tsks->taskInfos as $tsk){
						//echo "<li class=\"taskItem\">\n";
						echo "<li class=\"taskItem ".($tsk->status == TaskInfo::STATUS_FINISH ? "finish" : "")."\">\n";
						echo "<dl class=\"keyValDef\">\n";
						echo "<dt class=\"key name first\">名前:</dt>\n";
						echo "<dd class=\"val name\"><a href=\"./detail.php?taskid={$tsk->id}\">{$tsk->subjectName} {$tsk->name}</a></dd>\n";
						echo "<dt class=\"key\">期限:</dt>\n";
						echo "<dd class=\"val\">".date("m/d(D)", $tsk->limitDate)."</dd>\n";
						echo "<dt class=\"key\">優先順位:</dt>";
						echo "<dd class=\"val\">";
						switch ($tsk->priority){
							case TaskInfo::PRIORITY_NORMAL:
								echo "並";
								break;
							case TaskInfo::PRIORITY_HIGH:
								echo "高";
								break;
						}
						echo "</dd>";
						echo "<dt class=\"key\">状況:</dt>\n";
						echo "<dd class=\"val\">";
						switch ($tsk->status){
							case TaskInfo::STATUS_NOT_YET:
								echo "未着手";
								break;
							case TaskInfo::STATUS_FREEZE:
								echo "凍結";
								break;
							case TaskInfo::STATUS_FINISH:
								echo "完了";
								break;
						}
						echo "</dd>\n";
						echo "</dl>\n";
						echo "</li>\n";
					}
					echo "</ul>\n";
					echo "</li>\n";
				}
				?>
			</ul>
		</div>
	</div>
</body>
</html>