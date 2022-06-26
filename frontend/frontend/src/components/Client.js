import React, { useState, useEffect } from 'react';
import { useParams } from "react-router";
import GymDataService from '../services/gym'
import Image from 'react-bootstrap/Image';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Container from 'react-bootstrap/Container';
import Card from 'react-bootstrap/Card';

import Schedule from './Schedule'
import WorkoutPlan from './WorkoutPlan';
import Diet from './Diet';
import Attendence from './Attendence';
import Sidebar from './Sidebar';

const Client = props => {
    // let params = useParams();

    // const [movie, setMovie] = useState({
    //     id: null,
    //     title: "",
    //     rated: "",
    //     reviews: []
    // });

    // useEffect(() => {
    // const getMovie = id => {
    //TODO:
    //Implement getMovie
    // MovieDataService.findMovie(id)
    //     .then(response => {
    //         console.log(response);
    //         const obj = new Object();
    //         obj.id = response.data.id;
    //         obj.title = response.data.title;
    //         obj.rated = response.data.rated;
    //         obj.reviews = response.data.reviews;
    //         obj.poster = response.data.poster;
    //         obj.plot = response.data.plot;
    //         setMovie(obj);
    //     })
    //     .catch(e => {
    //         console.log(e);
    //     });
    // };
    // getMovie(params.id)
    // }, [params.id]);//if id change, then use effect


    // return (
    //     <div>
    //         <Container>
    //             <Row>
    //                 <Col>
    //                     <div className="poster">
    //                         <Image
    //                             className="bigPicture"
    //                             src={movie.poster + "/100px250"}
    //                             onError={({ currentTarget }) => {
    //                                 currentTarget.onerror = null;
    //                                 currentTarget.src = "/images/NoPosterAvailable-crop.jpg";
    //                             }}
    //                             fluid />
    //                     </div>
    //                 </Col>
    //                 <Col>
    //                     <Card>
    //                         <Card.Header as="h5">{movie.title}</Card.Header>
    //                         <Card.Body>
    //                             <Card.Text>
    //                                 {movie.plot}
    //                             </Card.Text>
    //                         </Card.Body>
    //                     </Card>
    //                     <h2>Reviews</h2>
    //                     <br></br>
    //                     {(movie.reviews || []).map((review, index) => {
    //                         return (
    //                             <div className="d-flex">
    //                                 <div className="flex-shrink-0 reviewsText">
    //                                     <h5>{review.name + " reviewed on "}</h5>
    //                                     <p className="review">{review.review}</p>
    //                                 </div>
    //                             </div>
    //                         )
    //                     })}
    //                 </Col>
    //             </Row>
    //         </Container>
    //     </div>
    // )

    return (
        <div className="Client">
            <Sidebar />
            <div id="page-wrap">
                Client Page Placeholder
                <Schedule />
                <Diet />
                <Attendence />
                <WorkoutPlan />
            </div>
        </div>

    )
}

export default Client;