let div1 = document.getElementById('appLeave'),
    div2 = document.getElementById('statusTable');

function showDivs(id) {
    if (id == 1) {
        div2.style.display = 'none';
        div1.style.display = 'block';
    } else {
        div1.style.display = 'none';
        div2.style.display = 'block';

    }
}


// show reply complain
function showRplyInput() {
    let status = document.getElementById('btnReply').parentElement.previousElementSibling.children.status,
        replayBox = document.getElementById('btnReply').parentElement.previousElementSibling.children.reply;
    if (status.style.display == 'block') {
        status.style.display = 'none';
        replayBox.style.display = 'block';
    } else {
        status.style.display = 'none';
        replayBox.style.display = 'block';

    }
}
// show reply complain

function showLeaveDivs(id) {
    let divs = document.getElementById('leaveDivs').children;
    for (let index = 0; index < divs.length; index++) {
        divs[index].style.display = 'none';
    }
    divs[id].style.display = 'block';
}