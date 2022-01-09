//GET JOB CATEGORY
function getJobCategory(jobCatetgory) {
    var text;

    switch (jobCatetgory) {
        case 1:
            text = "Part Time";
            break;
        case 2:
            text = "FullTime";
            break;
        case 3:
            text = "Contract";
            break;
        case 4:
            text = "Temporary";
            break;
        case 5:
            text = "Fixed Term";
            break;
        case 6:
            text = "Permanent";
            break;
    }

    return text;
}

//GET JOB STATUS USING STATUS ID
function getStatus(statusId) {
    var statusName = '';
    $.getJSON('@Url.Content("/api/GetStatusList")', function (data) {
        $.each(data, function (v, i) {
            if (i.Value == statusId) {
                statusName = i.Name;
            }
        });
    });

    return statusName;
}

//MISC 1
function getCityNameFromLocation(location) {
    var str = location.split(',');  //city, state, country
    return str[0] + ', ' + str[2];
}

//SEARCHES JOB QUERY ON JOBSLISTING
function searchJobBy(keywords, sector, location, experienceYears) {

    //LOADING UI MESSAGE
    //swal();

    // CASES ARE AS BELOW
    var url = "";

    // FIGURE OUT WHICH CASE TO HIT
    var caseIdentity = findCase(keywords, sector, location, experienceYears);

    switch (caseIdentity) {
        case 11:
            url = "";
            break;
        case 12:
            //code
            break;
        case 13:
            //code
            break;
        case 14:
            //code
            break;
        case 100:
            //code
            break;
        case 101:
            //code
            break;
        case 102:
            //code
            break;
        case 103:
            //code
            break;
        case 104:
            //code
            break;
        case 105:
            //code
            break;

        default:
            break;
    }

    // CASES SEARCH + OUTPUT
    fetch(url)
        .then(r => r.json())
        .then(jList => {
            var jobList = $('#jobList > div.row');

            jobList.html('');

            //ITERATE JOBS
            $.each(jList, function (v, i) {
                var jHtmlElement = '<div class="col-lg-12 col-md-12 col-sm-12 col-12">'
                    + '<div class="job_listing_left_fullwidth jb_cover">'
                    + '<div class="row">'
                    + '<div class="col-lg-9 col-md-9 col-sm-12 col-12">'
                    //+ '<div class="jp_job_post_side_img">'
                    //+ '<img src="~/App_Themes/Website/images/lt1.png" alt="post_img" />'
                    //+ '<br> <span>google</span>'
                    //+ '</div>'
                    + '<div class="jp_job_post_right_cont">'
                    + '<h4><a href="@Url.Content("~/jobs/apply/")' + i.JobId + '">' + i.Title + '</a></h4>'
                    + '<ul>'
                    + '<li><i class="flaticon-cash"></i>&nbsp; ' + getJobCategory(i.JobTypeId) + '</li>'
                    + '<li><i class="flaticon-location-pointer"></i>&nbsp;' + getCityNameFromLocation(i.LocationDetail) + '</li>'
                    + '</ul>'
                    + '</div>'
                    + '</div>'
                    + '<div class="col-lg-3 col-md-3 col-sm-12 col-12">'
                    + '<div class="jp_job_post_right_btn_wrapper">'
                    + '<ul>'
                    + '<li>'
                    //+ '<div class="job_adds_right">'
                    //+ '<a href="#!"><i class="far fa-heart"></i></a>'
                    //+ '</div>'
                    + '</li>'
                    //+ '<li><a href="job_single.html">Part Time</a></li>'
                    + '<li> <a href="#" data-toggle="modal" data-target="#myModal1">apply</a></li>'
                    + '</ul>'
                    + '</div>'
                    + '<div class="modal fade apply_job_popup" id="myModal1" role="dialog">'
                    + '<div class="modal-dialog">'
                    + '<div class="modal-content">'
                    + '<button type="button" class="close" data-dismiss="modal">&times;</button>'
                    + '<div class="row">'
                    + '<div class="col-lg-12 col-md-12 col-sm-12 col-12">'
                    + ''
                    + '<div class="apply_job jb_cover">'
                    + '<h1>apply for this job :</h1>'
                    + '<div class="search_alert_box jb_cover">'
                    + ''
                    + '<div class="apply_job_form">'
                    + ''
                    + '<input type="text" name="name" placeholder="full name">'
                    + '</div>'
                    + '<div class="apply_job_form">'
                    + ''
                    + '<input type="text" name="Email" placeholder="Enter Your Email">'
                    + '</div>'
                    + '<div class="apply_job_form">'
                    + '<textarea class="form-control" name="message" placeholder="Message"></textarea>'
                    + '</div>'
                    + ''
                    + '<div class="resume_optional jb_cover">'
                    + '<p>resume (optional)</p>'
                    + '<div class="width_50">'
                    + '<input type="file" id="input-file-now-custom-1" class="dropify" data-height="90"><span class="post_photo">upload resume</span>'
                    + '</div>'
                    + '<p class="word_file"> microsoft word or pdf file only (5mb)</p>'
                    + '</div>'
                    + '</div>'
                    + '<div class="header_btn search_btn applt_pop_btn jb_cover">'
                    + '<a href="#">apply now</a>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>'
                    + '</div>';

                //BINDING JOB LISTING
                jobList.append(jHtmlElement);
            });
        });
}

/* CASES FOR SEARCHES */
function findCase(k, s, l, e) {

    var value;

    //SINGLE CHECK
    if (k !== null || k !== "" || k !== '') {
        value =11;
    }
    else if (s !== null || s !== "" || s !== '') {
        value =12;
    }
    else if (l !== null || l !== "" || l !== '') {
        value =13;
    }
    else if (e !== null || e !== "" || e !== '') {
        value =14;
    }

    //MULTIPLE CHECK
    /// KEYWORD + SECTOR
    if ((k !== null || k !== "" || k !== '') && (s !== null || s !== "" || s !== '')) {
        value =100;
    }
    /// KEYWORD + LOCATION
    else if ((k !== null || k !== "" || k !== '') && (l !== null || l !== "" || l !== '')) {
        value =101;
    }
    /// KEYWORD + EXPERIENCE
    else if ((k !== null || k !== "" || k !== '') && (e !== null || e !== "" || e !== '')) {
        value =102;
    }
    // SECTOR + LOCATION
    else if ((s !== null || s !== "" || s !== '') && (l !== null || l !== "" || l !== '')) {
        value =103;
    }
    /// SECTOR + EXPERIENCE
    else if ((s !== null || s !== "" || s !== '') && (e !== null || e !== "" || e !== '')) {
        value =104;
    }
    /// LOCATION + EXPERIENCE
    else if ((l !== null || l !== "" || l !== '') && (e !== null || e !== "" || e !== '')) {
        value =105;
    }

    return value;
}