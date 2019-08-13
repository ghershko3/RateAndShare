$(document).ready(() => {
    const tabByURL = {
        'Rates': 'rates-tab',
        'Songs': 'songs-tab',
        'Statistics': 'statistics-tab',
        'Countries': 'weather-tab',
        'Users': '',
    }

    current_tab = tabByURL[Object.keys(tabByURL).find(tab => window.location.pathname.includes(tab))] || 'home-tab'

    $(`#${current_tab} a`).tab('show')

})