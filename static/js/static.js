//reference: https://www.w3schools.com/howto/howto_js_vertical_tabs.asp
function openTabContent(event, clothingItem) {
    var i, tabcontent, tablinks;

    //retrieve all the elements with tabcontent as their class, and hide them before displaying anything
    tabcontent = document.getElementsByClassName("tabcontent");
    for(i = 0; i < tabcontent.length; i++){
        tabcontent[i].style.display = "none"; 
    }

    //same thing for the actual tab buttons, but removing active 
    tablinks = document.getElementsByClassName("tab-link");
    for(i = 0; i < tablinks.length; i++){
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    //show current tab and add active to the current tab button
    document.getElementById(clothingItem).style.display = "block";
    event.currentTarget.className += " active";
}

//default tab: https://stackoverflow.com/questions/47771613/how-to-set-a-default-active-open-tab-in-html
function loadTabs() {
    document.getElementById("default-tab").click();

    var i, tabcontent;

    //retrieve all the elements with tabcontent as their class, and hide them before displaying anything
    tabcontent = document.getElementsByClassName("tabcontent");
    for(i = 0; i < tabcontent.length; i++){
        tabcontent[i].style.display = "none"; 
    }

    document.getElementById("tops").style.display = "block";
}