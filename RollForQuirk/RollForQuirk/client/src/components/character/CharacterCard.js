import React from "react"
import { Card, CardBody, CardText, CardTitle, CardSubtitle, Button } from "reactstrap"

export const CharacterCard = ({character}) =>{
    
    console.log("charObj",character)
    return (
        <Card>
        <CardTitle>{character?.characterName}</CardTitle>
        <CardBody>
            <CardSubtitle>Race: {character?.characterRace?.characterRace}</CardSubtitle>
            <CardSubtitle>Class: {character?.characterProfession?.characterProfession}</CardSubtitle>
            <CardSubtitle>Alignment: {character?.characterAlignment?.characterAlignment} </CardSubtitle>
            <CardSubtitle>Traits: </CardSubtitle>
        </CardBody>
    </Card>
    )
}