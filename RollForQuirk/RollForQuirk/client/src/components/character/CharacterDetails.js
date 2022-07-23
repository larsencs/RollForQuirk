import { useLocation, useParams, useNavigate, Link } from "react-router-dom"
import { useEffect, useState } from "react"
import { Card, CardBody, CardText, CardTitle, CardSubtitle, Button } from "reactstrap"

export const CharacterDetails = () =>{

    const location = useLocation()
    const navigate = useNavigate()
    const charId = location.state.id

    const handleDelete = () =>{
        console.log(charId)
    }

    return(
        <>
        <Card onClick={()=> navigate("/")}>

        <CardTitle>{location.state.characterName}</CardTitle>
        <CardBody>
            <CardSubtitle>Race: {location.state.characterRace.characterRace}</CardSubtitle>
            <CardSubtitle>Class: {location.state.characterProfession.characterProfession}</CardSubtitle>
            <CardSubtitle>Alignment: {location.state.characterAlignment.characterAlignment} </CardSubtitle>
            <CardSubtitle>Traits: {location.state.traits?.map(res => <CardText>{res.characterTrait}</CardText>)}</CardSubtitle>            
        </CardBody>
        </Card>
        <Button onClick={()=> navigate(`/${charId}/edit`)}>Edit</Button><Button onClick={handleDelete} className="btn btn-danger">Delete</Button>
        </>
    )
}