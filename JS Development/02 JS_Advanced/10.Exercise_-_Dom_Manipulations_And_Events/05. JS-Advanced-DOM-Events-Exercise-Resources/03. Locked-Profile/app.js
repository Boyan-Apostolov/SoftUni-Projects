// function lockedProfile() {
//     let radio = document.querySelectorAll('input[type="radio"]:checked').forEach(e=>e.addEventListener('change',(e)=>{
//         e.target.parentNode.querySelector('button').textContent = 'Show more'
//         e.target.parentNode.querySelector('div').style.display = 'none'
//     }))
//     document.querySelector('main').addEventListener('click', (e) => {
//         if (e.target.tagName == 'BUTTON') {
//             let isLocked = e.target.parentNode.querySelector('input[type="radio"]:checked').value == 'lock';
//             if(isLocked){
//                 return;
//             }
//             //
//             let isShown = e.target.textContent != 'Hide it'
//             if(isShown){
//                 e.target.textContent = 'Hide it'
//                 e.target.parentNode.querySelector('div').style.display = 'block'
//             } else {
//                 e.target.textContent = 'Show more'
//                 e.target.parentNode.querySelector('div').style.display = 'none'
//             }
//         }
//     });
// }
function lockedProfile() {
    document.getElementById('main').addEventListener('click', (e) => {
        if (e.target.tagName == 'BUTTON') {
            const profile = e.target.parentNode;
            const isLocked = profile
                .querySelector('input[type=radio]:checked').value == 'lock';

            if (isLocked) {
                return;
            }

            let div = profile.querySelector('div');
            let isVisible = div.style.display == 'block';

            div.style.display = isVisible ? 'none' : 'block'

            e.target.textContent = !isVisible ? 'Hide it' : 'Show more' 
        }
    })
}