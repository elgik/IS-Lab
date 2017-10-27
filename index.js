var udata = "";
var req = new XMLHttpRequest();
req.open('GET','data.json',true);
req.onreadystatechange = function(){
	if(req.readyState != 4) return;
	if(req.status == 200){
		udata = req.responseText;
	}
	else{
		return;
	}
	var ulist = JSON.parse(udata);
	console.log("ulist length: "+ulist.length);
	var udiv = document.createElement('div');
	udiv.className = 'idm_user';
	var stra = ""
	stra += "<table border = '1'>";
	stra += "<tr><th>Студент</th>"+
							"<th>Модуль 1</th>"+
							"<th>Модуль 2</th>"+
							"<th>Страница</th>"+
							"<th>Команда</th>"+
							"<th>Роль</th></tr>";
	
	for (var i = 0; i < ulist.students.length; i++){
		var sudata = ulist.students[i];
		
		stra += "<tr>";
		
		stra += "<td>"+sudata.name + "</td>";
		stra += "<td>"+sudata.module1 + "</td>";
		stra += "<td>"+sudata.module2 + "</td>";
		stra += "<td> <a href='https://stankin.github.io/inet-2017/idm-17-06/"+sudata.project + "'>Page link</a>" + "</td>";
		stra += "<td>"+sudata.team + "</td>";
		stra += "<td>"+sudata.role + "</td>";
		
		stra += "</tr>";
		
	}
	stra += "</table>";
	udiv.innerHTML = stra;
	var bdy = document.body;
	bdy.appendChild(udiv);
}
req.send();