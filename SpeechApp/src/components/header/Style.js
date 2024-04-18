import styled from "styled-components";

export const HeaderBody = styled.View`
    width: 100%;
    height: 160px;
    z-index: 3;
`

export const HeaderImage = styled.Image`
        width: 100%;
height: 100%;
`

export const Identify = styled.View`
    width: 50%;
    height: 70px;
    border-radius: 10px 0px 0px 0px;
    position: relative;
    bottom: 50px;
    left: 50%;
    border: 2px;
    justify-content: center;
    background-color: white;
`

export const Name = styled.Text`
    font-size: 16px;
    text-align: center;
`

export const Status = styled(Name)`
    font-size: 10px;
`