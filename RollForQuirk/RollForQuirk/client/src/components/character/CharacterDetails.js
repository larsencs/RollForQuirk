import { useLocation, useParams, useNavigate, Link } from "react-router-dom"
import { useEffect, useState } from "react"
import { Card, CardBody, CardText, CardTitle, CardSubtitle, Button, Modal, ModalBody, ModalHeader, ModalFooter } from "reactstrap"

export const CharacterDetails = ({character, isOpen, updateIsOpen}) =>{


    return(
        <>
        <Modal isOpen={isOpen} backdrop={true} toggle={()=> updateIsOpen(!isOpen)} className="container-sm">

        <ModalHeader>{character?.characterName}</ModalHeader>
        <ModalBody>
            <CardSubtitle>Race: {character?.characterRace?.characterRace}</CardSubtitle>
            <CardSubtitle>Class: {character?.characterProfession?.characterProfession}</CardSubtitle>
            <CardSubtitle>Alignment: {character?.characterAlignment?.characterAlignment} </CardSubtitle>
            <CardSubtitle>Traits: {character?.traits.map(res => <p>{res.characterTrait}</p>)}</CardSubtitle>         
        </ModalBody>
        
        <ModalFooter><Button>Edit</Button><Button className="btn btn-danger">Delete</Button></ModalFooter>
        </Modal>
        </>
    )
}