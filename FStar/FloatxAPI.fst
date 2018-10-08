module FloatxAPI

open FStar.Map

let isUri (s: string) =
  match s with
  | "https://www.gowithfloat.com" -> true
  | _ -> false

type uri = s: string{isUri s}

type language =
| English
| Spanish

type region =
| UnitedStates
| Mexico

type language_tag = (l: language) * (r: region)

type language_map = Map.t language_tag string

type verb = (id: uri) * (display: language_map)
